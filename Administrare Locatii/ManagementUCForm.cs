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
            Destinatie_comboBox.SelectedItem = dataGridView.SelectedCells[0].Value.ToString();
            Cazare.Text = dataGridView.SelectedCells[1].Value.ToString();
            Pret.Value = Decimal.Parse(dataGridView.SelectedCells[2].Value.ToString());
        }
    }
}
