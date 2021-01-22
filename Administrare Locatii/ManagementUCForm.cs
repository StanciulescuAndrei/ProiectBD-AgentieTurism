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

namespace AgentieTurismBackend.Administrare_Locatii
{
    public partial class ManagementUCForm : Form
    {
        SqlConnection conn;

        public ManagementUCForm(SqlConnection sqlConnection)
        {
            InitializeComponent();
            this.conn = sqlConnection;
        }

        private void UpdateDataView()
        {
            // Extragem unitatile de cazare si locatiile aferente in functie de termenul de cautare
            SqlCommand command = new SqlCommand("SELECT Dest.Denumire as Destinatie, UC.Nume as Cazare, UC.PretNoapte as Pret " +
                                                " FROM UnitatiCazare as UC JOIN Destinatie as Dest on UC.IDDestinatie = Dest.IDDestinatie" +
                                                " WHERE (Dest.Denumire LIKE @den) OR (UC.Nume LIKE @den)" +
                                                " ORDER BY UC.PretNoapte " + orderLabel.Text, conn);
            SqlParameter parameter1 = new SqlParameter { ParameterName = "@den", Value = "%" + searchTextBox.Text + "%" };
            command.Parameters.Add(parameter1);
            using (var reader = command.ExecuteReader())
            {
                dataGridView.Rows.Clear();
                dataGridView.ColumnCount = reader.FieldCount;

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dataGridView.Columns[i].Name = reader.GetName(i);
                }

                while (reader.Read())
                {
                    dataGridView.Rows.Add(reader[0], reader[1], reader[2]);
                }
            }
        }
        // Actualizeaza valorile posibile din meniul drop-down cu valorile din tabelul de detinatii
        private void UpdateLocations()
        {
            SqlCommand command = new SqlCommand("SELECT Denumire FROM Destinatie", conn);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Destinatie_comboBox.Items.Add(reader[0]);
                }
            }
        }

        private void ManagementUCForm_Load(object sender, EventArgs e)
        {
            UpdateDataView();
            UpdateLocations();
        }

        private void orderLabel_Click(object sender, EventArgs e)
        {
            if (orderLabel.Text == "ASC")
                orderLabel.Text = "DESC";
            else
                orderLabel.Text = "ASC";
            UpdateDataView();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            UpdateDataView();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.SelectedCells.Count != 3)
                return;
            Destinatie_comboBox.SelectedItem  = dataGridView.SelectedCells[0].Value.ToString();
            Cazare.Text = dataGridView.SelectedCells[1].Value.ToString();
            Pret.Value = Decimal.Parse(dataGridView.SelectedCells[1].Value.ToString());
        }

        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView.SelectedCells.Count != 3)
                return;
            // Cand apasam pe un cap de linie, toata linia va fi selectata, iar valorile vor fi extrase in campurile de sub tabel, pentru a face modificarea mai usoara
            Destinatie_comboBox.SelectedItem = dataGridView.SelectedCells[0].Value.ToString();
            Cazare.Text = dataGridView.SelectedCells[1].Value.ToString();
            Pret.Value = Decimal.Parse(dataGridView.SelectedCells[2].Value.ToString());
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Adauga o noua unitate de cazare, cu subcerere pentru cheia destinatiei
            SqlCommand command = new SqlCommand("INSERT into UnitatiCazare(IDDestinatie, Nume, PretNoapte) " +
                                                " values((SELECT IDDestinatie FROM Destinatie WHERE Denumire = @dest), @nume, @pret)", conn);
            SqlParameter parameter1 = new SqlParameter { ParameterName = "@dest", Value = Destinatie_comboBox.SelectedItem.ToString()};
            SqlParameter parameter2 = new SqlParameter { ParameterName = "@nume", Value = Cazare.Text };
            SqlParameter parameter3 = new SqlParameter { ParameterName = "@pret", Value = Pret.Value.ToString() };
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);
            command.Parameters.Add(parameter3);
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
            if (dataGridView.SelectedCells.Count != 3)
                return;
            // Modifica o anumita locatie de cazare, selectia se face in functie de campurile afisate, nu dupa cheia primara
            SqlCommand command = new SqlCommand(" UPDATE UnitatiCazare " +
                                                " SET IDDestinatie = (SELECT IDDestinatie FROM Destinatie WHERE Denumire = @dest_nou), Nume = @nume_nou, PretNoapte = @pret_nou" +
                                                " WHERE IDDestinatie = (SELECT IDDestinatie FROM Destinatie WHERE Denumire = @dest) AND Nume=@nume AND PretNoapte=@pret", conn);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@dest_nou", Value = Destinatie_comboBox.SelectedItem.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@nume_nou", Value = Cazare.Text });
            sqlParameters.Add(new SqlParameter { ParameterName = "@pret_nou", Value = Pret.Value.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@dest", Value = dataGridView.SelectedCells[0].Value.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@nume", Value = dataGridView.SelectedCells[1].Value.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@pret", Value = dataGridView.SelectedCells[2].Value.ToString() });

            foreach(SqlParameter parameter in sqlParameters)
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

        private void stergeButton_Click(object sender, EventArgs e)
        {
            // Sterge o anumita locatie de cazare, selectia se face in functie de campurile afisate, nu dupa cheia primara
            SqlCommand command = new SqlCommand("DELETE FROM UnitatiCazare " +
                                                " WHERE IDDestinatie = (SELECT IDDestinatie FROM Destinatie WHERE Denumire = @dest) AND Nume=@nume AND PretNoapte=@pret", conn);
            SqlParameter parameter1 = new SqlParameter { ParameterName = "@dest", Value = Destinatie_comboBox.SelectedItem.ToString() };
            SqlParameter parameter2 = new SqlParameter { ParameterName = "@nume", Value = Cazare.Text };
            SqlParameter parameter3 = new SqlParameter { ParameterName = "@pret", Value = Pret.Value.ToString() };
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);
            command.Parameters.Add(parameter3);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Pret_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Destinatie_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cazare_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
