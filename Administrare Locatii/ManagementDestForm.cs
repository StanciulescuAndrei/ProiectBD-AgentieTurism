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
    public partial class addButton : Form
    {
        SqlConnection conn;
        public addButton(SqlConnection sqlConnection)
        {
            InitializeComponent();
            this.conn = sqlConnection;
        }

        private void UpdateDataView()
        {
            SqlCommand command = new SqlCommand("SELECT Denumire FROM Destinatie WHERE Denumire LIKE @den ORDER BY Denumire ASC", conn);
            SqlParameter parameter = new SqlParameter { ParameterName = "@den", Value = "%" + searchTextBox.Text + "%" };
            command.Parameters.Add(parameter);
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
                    dataGridView.Rows.Add(reader[0]);
                }
            }
        }

        private void ManagementDestForm_Load(object sender, EventArgs e)
        {
            UpdateDataView();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            UpdateDataView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT into Destinatie(Denumire) values (@nume)", conn);
            SqlParameter parameter = new SqlParameter { ParameterName = "@nume", Value = fieldValue.Text};
            command.Parameters.Add(parameter);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception except)
            {
                MessageBox.Show(except.ToString(), "Eroare baza de date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateDataView();
            fieldValue.Text = "";
        }

        private void modificaButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count == 0)
                return;
            SqlCommand command = new SqlCommand("UPDATE Destinatie SET Denumire = @nume_nou WHERE Denumire = @nume_vechi", conn);
            SqlParameter parameter1 = new SqlParameter { ParameterName = "@nume_vechi", Value = dataGridView.SelectedCells[0].Value.ToString() };
            SqlParameter parameter2 = new SqlParameter { ParameterName = "@nume_nou", Value = fieldValue.Text };
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception except)
            {
                MessageBox.Show(except.ToString(), "Eroare baza de date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateDataView();
            fieldValue.Text = "";
        }

        private void stergeButton_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
            if (dataGridView.SelectedCells.Count == 0)
                return;
            SqlCommand command = new SqlCommand("DELETE from Destinatie WHERE Denumire = @nume", conn);
            SqlParameter parameter = new SqlParameter { ParameterName = "@nume", Value = dataGridView.SelectedCells[0].Value.ToString() };
            command.Parameters.Add(parameter);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception except)
            {
                MessageBox.Show(except.ToString(), "Eroare baza de date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateDataView();
            fieldValue.Text = "";
        }
    }
}
