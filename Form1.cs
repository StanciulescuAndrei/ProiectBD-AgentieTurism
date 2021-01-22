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

        readonly string connectionString = "Data Source=STANCIU\\SQLEXPRESS;Initial Catalog=AgentieTurism;Integrated Security=True";
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
            catch(Exception e)
            {
                statusLabel.Text = notConnStatus;
                MessageBox.Show(e.ToString());
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
            catch(NullReferenceException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseDBConnection();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenDBConnection();
        }

        private void ManagementDestButton_Click(object sender, EventArgs e)
        {
            Administrare_Locatii.addButton DestForm = new Administrare_Locatii.addButton(conn);
            DestForm.Show();
        }

        private void ManagementUCButton_Click(object sender, EventArgs e)
        {
            Administrare_Locatii.ManagementUCForm UCForm = new Administrare_Locatii.ManagementUCForm(conn);
            UCForm.Show();
        }

        private void ManagementExcButton_Click(object sender, EventArgs e)
        {
            Administrare_Locatii.ManagementExcForm ExcForm = new Administrare_Locatii.ManagementExcForm(conn);
            ExcForm.Show();
        }

        private void ManagementClientiButton_Click(object sender, EventArgs e)
        {
            Administrare_Clienti.ManagementClientiForm ClientiForm = new Administrare_Clienti.ManagementClientiForm(conn);
            ClientiForm.Show();
        }

        private void ManagementRzvButton_Click(object sender, EventArgs e)
        {
            Administrare_Clienti.ManagementRzvForm RzvForm = new Administrare_Clienti.ManagementRzvForm(conn);
            RzvForm.Show();
        }

        private void regClientExcButton_Click(object sender, EventArgs e)
        {
            AdminComplex.RegClientExc regClientExc = new AdminComplex.RegClientExc(conn);
            regClientExc.Show();
        }

        private void statExcursii_Click(object sender, EventArgs e)
        {
            AdminComplex.StatExcursii statExcursii = new AdminComplex.StatExcursii(conn);
            statExcursii.Show();
        }
    }
}
