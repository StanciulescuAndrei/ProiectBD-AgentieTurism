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

namespace AgentieTurismBackend.AdminComplex
{
    public partial class StatExcursii : Form
    {
        SqlConnection conn;
        public StatExcursii(SqlConnection sqlConnection)
        {
            InitializeComponent();
            conn = sqlConnection;
        }

        private void UpdateDataTable(SqlCommand command)
        {
            // Umple tabelul din interfata cu rezultatele comanzii executate
            using (var reader = command.ExecuteReader())
            {
                dataGrid.Rows.Clear();
                dataGrid.ColumnCount = reader.FieldCount;

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dataGrid.Columns[i].Name = reader.GetName(i);
                    dataGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                while (reader.Read())
                {
                    List<object> readData = new List<object>();
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        readData.Add(reader[i]);
                    }
                    dataGrid.Rows.Add(readData.ToArray());
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Afiseaza toate excursiile care au un grad de umplere peste x%, descrescator in functie de x pentru data y
            SqlCommand command = new SqlCommand("SELECT E.Denumire, (" +
                                                "                   SELECT cast(cast(count(1) * 100.00 / E.NrMaximParticipanti as decimal(10, 2)) as nvarchar(6)) + \'%\'" +
                                                "                   FROM Rezervare as R " +
                                                "                   JOIN ClientRezervare as CR" +
                                                "                   ON R.IDRezervare = CR.IDRezervare"+
                                                "                   WHERE R.DataPlecare = @data and R.IDExcursie = E.IDExcursie"+
                                                "                   ) as ProcentOcupare"+
                                                " FROM Excursie as E"+
                                                " WHERE @proc < (    "+
                                                "               SELECT count(1) * 100.00 / E.NrMaximParticipanti"+
                                                "               FROM Rezervare as R"+
                                                "               JOIN ClientRezervare as CR"+
                                                "               ON R.IDRezervare = CR.IDRezervare"+
                                                "               WHERE R.DataPlecare = @data and R.IDExcursie = E.IDExcursie"+
                                                "             )"+
                                                " order by ProcentOcupare DESC", conn);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@data", Value = dateTimePicker1.Value.ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@proc", Value = Convert.ToInt32(numericUpDown1.Value) });

            foreach (SqlParameter parameter in sqlParameters)
            {
                command.Parameters.Add(parameter);
            }
            UpdateDataTable(command);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Clientii care au cheltuit cel mai mult pe platforma (suma costurilor excursiilor) din data x pana in prezent
            SqlCommand command = new SqlCommand("SELECT C.Nume, C.Prenume, SUM(E.PretBaza) as Total            "+
                                                "FROM Client as C                                              "+
                                                "JOIN ClientRezervare as CR ON C.IDClient = CR.IDClient        "+
                                                "JOIN Rezervare as R on R.IDRezervare = CR.IDRezervare         "+
                                                "JOIN Excursie as E on E.IDExcursie = R.IDExcursie             "+
                                                "WHERE R.IDRezervare in (                                      "+
                                                "                        SELECT Rez.IDRezervare                "+
                                                "                        FROM Rezervare as Rez                 "+
                                                "                        WHERE Rez.DataPlecare >= @data)"+
                                                "GROUP BY C.Nume, C.Prenume                                    "+
                                                "ORDER BY Total DESC", conn);                                   
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@data", Value = dateTimePicker2.Value.ToString() });

            foreach (SqlParameter parameter in sqlParameters)
            {
                command.Parameters.Add(parameter);
            }
            UpdateDataTable(command);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Top x cele mai populare orase in functie de rezervari si in care exista maxim o excursie care duce acolo
            SqlCommand command = new SqlCommand("SELECT TOP (@top) D.Denumire, (                                      "+
                                                "                            SELECT COUNT(R.IDRezervare)         "+
                                                "                            FROM Rezervare as R                 "+
                                                "                            WHERE R.IDExcursie = E.IDExcursie   "+
                                                "                         ) as TotalRezervari                    "+
                                                "FROM Destinatie as D                                            "+
                                                "JOIN Excursie as E on E.IDDestinatie = D.IDDestinatie           "+
                                                "WHERE 1 = (                                                     "+
                                                "            SELECT count(E2.IDExcursie)                         "+
                                                "            FROM Excursie as E2                                 "+
                                                "            WHERE E2.IDDestinatie = D.IDDestinatie              "+
			                                    "           )                                                    "+
                                                "ORDER BY TotalRezervari DESC", conn);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@top", Value = Convert.ToInt32(numericUpDown2.Value) });

            foreach (SqlParameter parameter in sqlParameters)
            {
                command.Parameters.Add(parameter);
            }
            UpdateDataTable(command);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Cazarile unde nu s-au mai facut rezervari in ultimele x luni si costa peste y lei pe noapte
            SqlCommand command = new SqlCommand("SELECT UC.Nume, D.Denumire, UC.PretNoapte                 "+
                                                "FROM UnitatiCazare as UC                                  "+
                                                "JOIN Destinatie as D on D.IDDestinatie = UC.IDDestinatie  "+
                                                "WHERE UC.PretNoapte > @pret                               "+
                                                "and                                                       "+
                                                " NOT EXISTS (SELECT *                                     "+
                                                "        FROM Rezervare as R                               "+
                                                "        WHERE R.IDCazare = UC.IDCazare                    "+
                                                "        and R.DataPlecare > @data)", conn);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@data", Value = DateTime.Now.AddMonths(-1 * Convert.ToInt32(numericUpDown3.Value)).ToString() });
            sqlParameters.Add(new SqlParameter { ParameterName = "@pret", Value = Convert.ToInt32(numericUpDown4.Value) });

            foreach (SqlParameter parameter in sqlParameters)
            {
                command.Parameters.Add(parameter);
            }
            UpdateDataTable(command);
        }

        private void StatExcursii_Load(object sender, EventArgs e)
        {

        }
    }
}
