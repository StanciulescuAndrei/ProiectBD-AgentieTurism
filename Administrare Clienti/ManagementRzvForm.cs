using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AgentieTurismBackend.Administrare_Clienti
{
    public partial class ManagementRzvForm : Form
    {
        SqlConnection conn;
        public ManagementRzvForm(SqlConnection sqlConnection)
        {
            InitializeComponent();
            this.conn = sqlConnection;
        }

        private void UpdateExcursie()
        {
            SqlCommand command = new SqlCommand("SELECT Denumire FROM Excursie", conn);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Excursie_comboBox.Items.Add(reader[0]);
                }
            }
        }

        private void UpdateCazare()
        {
            SqlCommand command = new SqlCommand("SELECT Nume FROM UnitatiCazare", conn);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Cazare_comboBox.Items.Add(reader[0]);
                }
            }
        }


        private void UpdateDataView()
        {
            // Extrage rezervarile din baza de date, selectate in functie de termenul de cautare, impreuna cu excursia, cazarea si clientul
            SqlCommand command = new SqlCommand("SELECT Rzv.IDRezervare, Ex.Denumire as Excursie, Cazare.Nume as Cazare, Client.Nume as NumeClient ," +
                                                " Client.Prenume as PrenumeClient, Rzv.DataPlecare as Data, Rzv.Avans as Avans" +
                                                " FROM Rezervare as Rzv" +
                                                " JOIN Excursie as Ex on Ex.IDExcursie = Rzv.IDExcursie" +
                                                " JOIN UnitatiCazare as Cazare on Cazare.IDCazare = Rzv.IDCazare" +
                                                " JOIN ClientRezervare as CR on CR.IDRezervare = Rzv.IDRezervare" +
                                                " JOIN CLIENT as Client on Client.IDClient = CR.IDClient" +
                                                " WHERE ( Cazare.Nume LIKE @den) OR (Client.Nume LIKE @den) OR (Client.Prenume LIKE @den)" +
                                                " ORDER BY Rzv.DataPlecare " + orderLabel.Text, conn);
            SqlParameter parameter1 = new SqlParameter { ParameterName = "@den", Value = "%" + searchTextBox.Text + "%" };
            command.Parameters.Add(parameter1);
            using (var reader = command.ExecuteReader())
            {
                dataGridView.Rows.Clear();
                dataGridView.ColumnCount = reader.FieldCount;

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dataGridView.Columns[i].Name = reader.GetName(i);
                    dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                while (reader.Read())
                {
                    dataGridView.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], Convert.ToDateTime(reader[5]).Date.ToString("dd/MM/yyyy"), reader[6]);
                }
                dataGridView.Columns[0].Visible = false; // Nu vrem ca ID-ul sa fie vizibil

            }

        }

        private void ManagementRzvForm_Load(object sender, EventArgs e)
        {
            UpdateDataView();
            UpdateCazare();
            UpdateExcursie();
        }

        private void orderLabel_Click(object sender, EventArgs e)
        {
            if (orderLabel.Text == "ASC")
                orderLabel.Text = "DESC";
            else
                orderLabel.Text = "ASC";
            UpdateDataView();
        }

        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Verificam sa avem un rand intreg selectat
            if (dataGridView.SelectedCells.Count != 7)
                return;
            // Cand apasam pe un cap de linie, toata linia va fi selectata, iar valorile vor fi extrase in campurile de sub tabel, pentru a face modificarea mai usoara
            Excursie_comboBox.SelectedItem = dataGridView.SelectedCells[1].Value.ToString();
            Cazare_comboBox.SelectedItem = dataGridView.SelectedCells[2].Value.ToString();
            Avans.Value = Decimal.Parse(dataGridView.SelectedCells[6].Value.ToString());
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView.SelectedCells[5].Value.ToString());

        }

        private void stergeButton_Click(object sender, EventArgs e)
        {
            // Sterge rezervarea in functie de cheia primara selectata
            SqlCommand command = new SqlCommand("DELETE FROM Rezervare " +
                                                " WHERE IDRezervare = @id", conn);
            SqlParameter parameter1 = new SqlParameter { ParameterName = "@id", Value = dataGridView.SelectedCells[0].Value.ToString() };
            command.Parameters.Add(parameter1);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception except)
            {
                MessageBox.Show(except.ToString(), "Eroare baza de date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateDataView();
        }

        private void modificaButton_Click(object sender, EventArgs e)
        {
            // Verificam sa avem un rand intreg selectat
            if (dataGridView.SelectedCells.Count != 7)
                return;
            // Modificam cu noile valori in functie de cheia primara selectata
            SqlCommand command = new SqlCommand(" UPDATE Rezervare " +
                                                " SET IDExcursie = (SELECT IDExcursie FROM Excursie WHERE Denumire = @exc_nou)," +
                                                " IDCazare = (SELECT IDCazare FROM UnitatiCazare WHERE Nume = @cazare_nou)," +
                                                " DataPlecare = @data_nou," +
                                                " Avans = @avans_nou" +
                                                " WHERE IDRezervare = @id", conn);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@exc_nou", Value = Excursie_comboBox.SelectedItem.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@cazare_nou", Value = Cazare_comboBox.SelectedItem.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@data_nou", Value = dateTimePicker1.Value.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@avans_nou", Value = Avans.Value.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@id", Value = dataGridView.SelectedCells[0].Value.ToString() });

            foreach (SqlParameter parameter in sqlParameters)
            {
                command.Parameters.Add(parameter);
            }
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception except)
            {
                MessageBox.Show(except.ToString(), "Eroare baza de date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateDataView();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            UpdateDataView();
        }
    }
}
