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
    public partial class ManagementExcForm : Form
    {
        SqlConnection conn;
        public ManagementExcForm(SqlConnection sqlConnection)
        {
            InitializeComponent();
            this.conn = sqlConnection;
        }

        private void UpdateCategorii()
        {
            // Actualizeaza valorile posibile din meniul drop-down cu valorile din tabelul de categorii
            SqlCommand command = new SqlCommand("SELECT Denumire FROM Categorie", conn);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Categorie_comboBox.Items.Add(reader[0]);
                }
            }
        }

        private void UpdateDestinatii()
        {
            // Actualizeaza valorile posibile din meniul drop-down cu valorile din tabelul de detinatii
            SqlCommand command = new SqlCommand("SELECT Denumire FROM Destinatie", conn);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Destinatie_comboBox.Items.Add(reader[0]);
                }
            }
        }

        private void UpdateDataView()
        {
            // Extrage excursiile din baza de date, impreuna cu destinatiile si categoriile respective, ca sa nu fie afisate chei artificiale
            SqlCommand command = new SqlCommand("SELECT Ex.IDExcursie, Cat.Denumire as Categorie, Dest.Denumire as Destinatie, Ex.Denumire as Denumire, Ex.Durata as Durata, Ex.NrMaximParticipanti as MaxParticipanti, Ex.PretBaza as PretBaza, Ex.Transport as TransportInclus " +
                                                " FROM Excursie as Ex JOIN Destinatie as Dest on Ex.IDDestinatie = Dest.IDDestinatie" +
                                                " JOIN Categorie as Cat on Ex.IDCategorie = Cat.IDCategorie" +
                                                " WHERE (Dest.Denumire LIKE @den) OR (Ex.Denumire LIKE @den) OR (Cat.Denumire LIKE @den)" +
                                                " ORDER BY Ex.PretBaza " + orderLabel.Text, conn);
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
                    dataGridView.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7]);
                }
                dataGridView.Columns[0].Visible = false; // Nu vrem ca ID-ul sa fie vizibil

            }

            


        }

        private void ManagementExcForm_Load(object sender, EventArgs e)
        {
            UpdateDataView();
            UpdateDestinatii();
            UpdateCategorii();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Inserarea unei valori noi cu subcereri pentru a obtine cheia primara in functie de denumire (pentru categorie si destinatie)
            SqlCommand command = new SqlCommand("INSERT into Excursie(IDCategorie, IDDestinatie, Denumire, Durata, NrMaximParticipanti, PretBaza, Transport) " +
                                                " values(" +
                                                "(SELECT IDCategorie FROM Categorie WHERE Denumire = @cat), " +
                                                "(SELECT IDDestinatie FROM Destinatie WHERE Denumire = @dest), " +
                                                " @nume, " +
                                                " @durata, " +
                                                " @maxpart, " +
                                                " @pret, " +
                                                " @trans)", conn);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@cat", Value = Categorie_comboBox.SelectedItem.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@dest", Value = Destinatie_comboBox.SelectedItem.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@nume", Value = Denumire.Text });
            sqlParameters.Add(new SqlParameter { ParameterName = "@durata", Value = Convert.ToInt32(Durata.Value).ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@maxpart", Value = Convert.ToInt32(Participanti.Value).ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@pret", Value = Convert.ToInt32(Pret.Value).ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@trans", Value = Transport.Checked });

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

        private void modificaButton_Click(object sender, EventArgs e)
        {
            // Verificam sa avem un rand intreg selectat
            if (dataGridView.SelectedCells.Count != 8)
                return;
            // Facem update cu noile valori dupa ID
            SqlCommand command = new SqlCommand(" UPDATE Excursie " +
                                                " SET IDCategorie = (SELECT IDCategorie FROM Categorie WHERE Denumire = @cat_nou)," +
                                                " IDDestinatie = (SELECT IDDestinatie FROM Destinatie WHERE Denumire = @dest_nou)," +
                                                " Denumire = @nume_nou," +
                                                " Durata = @durata_nou," +
                                                " NrMaximParticipanti = @part_nou," +
                                                " PretBaza = @pret_nou," +
                                                " Transport = @trans_nou" +
                                                " WHERE IDExcursie = @id", conn);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@dest_nou", Value = Destinatie_comboBox.SelectedItem.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@cat_nou", Value = Categorie_comboBox.SelectedItem.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@pret_nou", Value = Pret.Value.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@part_nou", Value = Participanti.Value.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@durata_nou", Value = Durata.Value.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@nume_nou", Value = Denumire.Text });
            sqlParameters.Add(new SqlParameter { ParameterName = "@trans_nou", Value = Transport.Checked.ToString() });
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

        private void stergeButton_Click(object sender, EventArgs e)
        {
            // Verificam sa avem un rand intreg selectat
            if (dataGridView.SelectedCells.Count != 8)
                return;
            // Stergem excursia in functie de ID
            SqlCommand command = new SqlCommand("DELETE FROM Excursie " +
                                                " WHERE IDExcursie = @id", conn);
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

        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView.SelectedCells.Count != 8)
                return;
            // Cand apasam pe un cap de linie, toata linia va fi selectata, iar valorile vor fi extrase in campurile de sub tabel, pentru a face modificarea mai usoara
            Categorie_comboBox.SelectedItem = dataGridView.SelectedCells[1].Value.ToString();
            Destinatie_comboBox.SelectedItem = dataGridView.SelectedCells[2].Value.ToString();
            Denumire.Text = dataGridView.SelectedCells[3].Value.ToString();
            Durata.Value = Decimal.Parse(dataGridView.SelectedCells[4].Value.ToString());
            Participanti.Value = Decimal.Parse(dataGridView.SelectedCells[5].Value.ToString());
            Pret.Value = Decimal.Parse(dataGridView.SelectedCells[6].Value.ToString());
            Transport.Checked = dataGridView.SelectedCells[7].Value.ToString() == "True";
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
    }
}
