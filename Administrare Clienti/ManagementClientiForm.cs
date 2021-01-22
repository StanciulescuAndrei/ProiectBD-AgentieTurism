using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AgentieTurismBackend.Administrare_Clienti
{
    public partial class ManagementClientiForm : Form
    {
        SqlConnection conn;
        public ManagementClientiForm(SqlConnection sqlConnection)
        {
            InitializeComponent();
            this.conn = sqlConnection;
        }

        private void UpdateDataView()
        {
            // Extrage clientii din baza de date, selectate in functie de termenul de cautare
            SqlCommand command = new SqlCommand("SELECT IDClient, Nume, Prenume, CNP, DataNasterii, Telefon, email as 'EMAIL'" +
                                                " FROM Client" +
                                                " WHERE ( Nume LIKE @den) OR (Prenume LIKE @den) OR (Nume LIKE @den) OR (CNP LIKE @den) OR (email LIKE @den) OR (Telefon LIKE @den)" +
                                                " ORDER BY Nume " + orderLabel.Text, conn);
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
                    dataGridView.Rows.Add(reader[0], reader[1], reader[2], reader[3], Convert.ToDateTime(reader[4]).Date.ToString("dd/MM/yyyy"), reader[5], reader[6]);
                }
                dataGridView.Columns[0].Visible = false; // Nu vrem ca ID-ul sa fie vizibil

            }

        }


        private void ManagementClientiForm_Load(object sender, EventArgs e)
        {
            UpdateDataView();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            UpdateDataView();
        }

        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Verificam sa avem un rand intreg selectat
            if (dataGridView.SelectedCells.Count != 7)
                return;
            // Cand apasam pe un cap de linie, toata linia va fi selectata, iar valorile vor fi extrase in campurile de sub tabel, pentru a face modificarea mai usoara
            Nume.Text = dataGridView.SelectedCells[1].Value.ToString();
            Prenume.Text = dataGridView.SelectedCells[2].Value.ToString();
            CNP.Text = dataGridView.SelectedCells[3].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView.SelectedCells[4].Value.ToString());
            Telefon.Text = dataGridView.SelectedCells[5].Value.ToString();
            Email.Text = dataGridView.SelectedCells[6].Value.ToString();
        }

        private void modificaButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count != 7)
                return;
            // Verificam sa avem valori valide pentru telefon si CNP
            if (CNP.TextLength != 13 || Regex.IsMatch(Telefon.Text, @"^[a-zA-Z]+$") || Regex.IsMatch(CNP.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("CNP sau Telefon invalid");
                return;
            }
            // Update In tabela cu noile valori in functie de cheia primara selectata
            SqlCommand command = new SqlCommand(" UPDATE Client " +
                                                " SET Nume = @nume_nou," +
                                                " Prenume = @prenume_nou," +
                                                " CNP = @cnp_nou," +
                                                " DataNasterii = @data_nou," +
                                                " Telefon = @tel_nou," +
                                                " email = @email_nou" +
                                                " WHERE IDClient = @id", conn);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@nume_nou", Value = Nume.Text });
            sqlParameters.Add(new SqlParameter { ParameterName = "@prenume_nou", Value = Prenume.Text });
            sqlParameters.Add(new SqlParameter { ParameterName = "@data_nou", Value = dateTimePicker1.Value.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@cnp_nou", Value = CNP.Text });
            sqlParameters.Add(new SqlParameter { ParameterName = "@tel_nou", Value = Telefon.Text });
            sqlParameters.Add(new SqlParameter { ParameterName = "@email_nou", Value = Email.Text });
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

        private void orderLabel_Click(object sender, EventArgs e)
        {
            if (orderLabel.Text == "ASC")
                orderLabel.Text = "DESC";
            else
                orderLabel.Text = "ASC";
            UpdateDataView();
        }

        private void stergeButton_Click(object sender, EventArgs e)
        {
            // Stergerea unui client in functie de cheia primara
            SqlCommand command = new SqlCommand("DELETE FROM Client " +
                                                " WHERE IDClient = @id", conn);
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

        private void addButton_Click(object sender, EventArgs e)
        {
            // Verificam sa avem valori valide pentru telefon si CNP
            if (CNP.TextLength != 13 || Regex.IsMatch(Telefon.Text, @"^[a-zA-Z]+$") || Regex.IsMatch(CNP.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("CNP sau Telefon invalid");
                return;
            }
            // Insert cu noile valori daca verificarea are succes
            SqlCommand command = new SqlCommand("INSERT into Client(Nume, Prenume, CNP, DataNasterii, Telefon, email) " +
                                                " values(@nume, @prenume, @cnp, @data, @tel, @email)", conn);

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@nume", Value = Nume.Text });
            sqlParameters.Add(new SqlParameter { ParameterName = "@prenume", Value = Prenume.Text });
            sqlParameters.Add(new SqlParameter { ParameterName = "@data", Value = dateTimePicker1.Value.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@cnp", Value = CNP.Text });
            sqlParameters.Add(new SqlParameter { ParameterName = "@tel", Value = Telefon.Text });
            sqlParameters.Add(new SqlParameter { ParameterName = "@email", Value = Email.Text });
            foreach (SqlParameter parameter in sqlParameters)
            {
                command.Parameters.Add(parameter);
            }

            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception except)
            {
                MessageBox.Show(except.ToString(), "Eroare baza de date",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateDataView();
        }
    }
}
