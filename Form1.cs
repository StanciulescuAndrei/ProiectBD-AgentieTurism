using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgentieTurismBackend
{
    public partial class Form1 : Form
    {

        readonly string connectionString = "Data Source=FUJITSU\\SQLEXPRESS;Initial Catalog=AgentieTurism;Integrated Security=True";
        SqlConnection conn = null;

        readonly string connStatus = "Status: Database connected";
        readonly string notConnStatus = "Status: Not connected";

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenDBConnection()
        {
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                statusLabel.Text = connStatus;
            }
            catch
            {
                statusLabel.Text = notConnStatus;
            }
        }

        private void CloseDBConnection()
        {
            try
            {
                conn.Close();
                conn.Dispose();
                conn = null;
                statusLabel.Text = notConnStatus;
            }
            catch
            {

            }
        }

        private void ConnectToDB_Click(object sender, EventArgs e)
        {
            OpenDBConnection();   
        }

        private void DisposeDB_Click(object sender, EventArgs e)
        {
            CloseDBConnection();
        }

        private void TestQuery_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = conn,
                CommandText = "SELECT UnitatiCazare.Nume, UnitatiCazare.PretNoapte, Destinatie.Denumire AS Oras " +
                              "FROM UnitatiCazare JOIN Destinatie ON UnitatiCazare.IDDestinatie = Destinatie.IDDestinatie" +
                              " WHERE Destinatie.Denumire LIKE @match"
            };
            SqlParameter matchParam = new SqlParameter
            {
                ParameterName = "@match",
                Value = textBox1.Text + "%"
            };
            cmd.Parameters.Add(matchParam);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                queryResult.Clear();
                for(int i = 0; i < reader.FieldCount; i++)
                {
                    queryResult.AppendText(reader.GetName(i) + "\t\t");
                }
                queryResult.AppendText("\r\n\r\n");
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        queryResult.AppendText(reader[i] + "\t\t");
                    }
                    queryResult.AppendText("\r\n");
                }
            }
            catch
            {
                MessageBox.Show("DB Error!");
            }
            finally
            {
                cmd.Dispose();
                CloseDBConnection();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseDBConnection();
            
        }
    }
}
