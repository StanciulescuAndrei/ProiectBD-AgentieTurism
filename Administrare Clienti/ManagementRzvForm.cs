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
    }
}
