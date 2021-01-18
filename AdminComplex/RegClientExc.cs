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
    public partial class RegClientExc : Form
    {
        SqlConnection conn;
        public RegClientExc(SqlConnection sqlConnection)
        {
            InitializeComponent();
            conn = sqlConnection;
        }

        private void UpdateClientiView()
        {
            SqlCommand command = new SqlCommand("SELECT IDClient, Nume, Prenume, CNP" +
                                                " FROM Client" +
                                                " WHERE ( Nume LIKE @den) OR (Prenume LIKE @den) OR (Nume LIKE @den) OR (CNP LIKE @den)", conn);
            SqlParameter parameter1 = new SqlParameter { ParameterName = "@den", Value = "%" + searchClient.Text + "%" };
            command.Parameters.Add(parameter1);
            using (var reader = command.ExecuteReader())
            {
                clientiGrid.Rows.Clear();
                clientiGrid.ColumnCount = reader.FieldCount;

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    clientiGrid.Columns[i].Name = reader.GetName(i);
                    clientiGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                while (reader.Read())
                {
                    clientiGrid.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
                clientiGrid.Columns[0].Visible = false; // Nu vrem ca ID-ul sa fie vizibil

            }

        }

        private void UpdateExcursiiView()
        {
            SqlCommand command = new SqlCommand("SELECT Ex.IDExcursie, Cat.Denumire as Categorie, Dest.Denumire as Destinatie, Ex.Denumire as Denumire, Ex.Durata as Durata, Ex.NrMaximParticipanti as MaxParticipanti, Ex.PretBaza as PretBaza, Ex.Transport as TransportInclus " +
                                                 " FROM Excursie as Ex JOIN Destinatie as Dest on Ex.IDDestinatie = Dest.IDDestinatie" +
                                                 " JOIN Categorie as Cat on Ex.IDCategorie = Cat.IDCategorie" +
                                                 " WHERE (Dest.Denumire LIKE @den) OR (Ex.Denumire LIKE @den) OR (Cat.Denumire LIKE @den)", conn);
            SqlParameter parameter1 = new SqlParameter { ParameterName = "@den", Value = "%" + searchExcursii.Text + "%" };
            command.Parameters.Add(parameter1);
            using (var reader = command.ExecuteReader())
            {
                excursiiGrid.Rows.Clear();
                excursiiGrid.ColumnCount = reader.FieldCount;

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    excursiiGrid.Columns[i].Name = reader.GetName(i);
                    excursiiGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                while (reader.Read())
                {
                    excursiiGrid.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7]);
                }
                excursiiGrid.Columns[0].Visible = false; // Nu vrem ca ID-ul sa fie vizibil

            }

        }

        private void UpdateCazareView()
        {
            SqlCommand command = new SqlCommand("SELECT UC.IDCazare, UC.Nume as Cazare, Dest.Denumire as Destinatie, UC.PretNoapte as Pret " +
                                                 " FROM UnitatiCazare as UC JOIN Destinatie as Dest on UC.IDDestinatie = Dest.IDDestinatie" +
                                                 " WHERE (Dest.Denumire LIKE @den) OR (UC.Nume LIKE @den)", conn);
            SqlParameter parameter1 = new SqlParameter { ParameterName = "@den", Value = "%" + searchCazare.Text + "%" };
            command.Parameters.Add(parameter1);
            using (var reader = command.ExecuteReader())
            {
                cazareGrid.Rows.Clear();
                cazareGrid.ColumnCount = reader.FieldCount;

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    cazareGrid.Columns[i].Name = reader.GetName(i);
                    cazareGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                while (reader.Read())
                {
                    cazareGrid.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
                cazareGrid.Columns[0].Visible = false; // Nu vrem ca ID-ul sa fie vizibil
            }

        }

        private void RegClientExc_Load(object sender, EventArgs e)
        {
            UpdateCazareView();
            UpdateClientiView();
            UpdateExcursiiView();
        }

        private void btnSearchclienti_Click(object sender, EventArgs e)
        {
            UpdateClientiView();
        }

        private void btnSearchExcursii_Click(object sender, EventArgs e)
        {
            UpdateExcursiiView();
        }

        private void btnSearchCazare_Click(object sender, EventArgs e)
        {
            UpdateCazareView();
        }

        private void regRezerv_Click(object sender, EventArgs e)
        {
            // Verificam mai intai daca au fost selectate corect datele:
            if(excursiiGrid.SelectedCells.Count != 8)
            {
                MessageBox.Show("Nu ati selectat o excursie!", "Eroare selectie date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cazareGrid.SelectedCells.Count != 4)
            {
                MessageBox.Show("Nu ati selectat o cazare!", "Eroare selectie date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(clientiGrid.SelectedCells.Count == 0 || clientiGrid.SelectedCells.Count % 4 != 0) // Se pot alege mai multi clienti
            {
                MessageBox.Show("Nu ati selectat clientii!", "Eroare selectie date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Verificam daca s-a ales cazarea in acelasi oras ca exscursia
            if(excursiiGrid.SelectedCells[2].Value.ToString().CompareTo(cazareGrid.SelectedCells[2].Value.ToString()) != 0)
            {
                MessageBox.Show("Cazarea nu e in acelasi oras ca excursia!", "Eroare selectie date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int lastID = 0;
            // Mai intai generam noua rezervare, apoi o conectam cu clientii respectivi prin tabelul de legatura
            using (var command = new SqlCommand("INSERT into Rezervare(IDExcursie, IDCazare, DataPlecare, Avans) " +
                                                " values(" +
                                                " @id_excursie, " +
                                                " @id_cazare, " +
                                                " @data_plecare, " +
                                                " @avans) \r\n SELECT SCOPE_IDENTITY(); ", conn))
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter { ParameterName = "@id_excursie", Value = excursiiGrid.SelectedCells[0].Value });
                sqlParameters.Add(new SqlParameter { ParameterName = "@id_cazare", Value = cazareGrid.SelectedCells[0].Value });
                sqlParameters.Add(new SqlParameter { ParameterName = "@data_plecare", Value = dataPlecare.Value.ToString() });
                sqlParameters.Add(new SqlParameter { ParameterName = "@avans", Value = Convert.ToInt32(Avans.Value).ToString() });

                foreach (SqlParameter parameter in sqlParameters)
                {
                    command.Parameters.Add(parameter);
                }
                try
                {
                    // Acum incercam sa luam ID-ul generat automat pentru rezervarea pe care tocmai am facut-o
                    using (var reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                            lastID = Convert.ToInt32(reader[0]);
                    }
                }
                catch (Exception except)
                {
                    MessageBox.Show(except.ToString(), "Eroare baza de date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // Acum inseram in tabelul de legatura asocieri intre acest ID si ID-urile tuturor clientilor selectati pentru rezervare

            for (int i = 0; i < clientiGrid.SelectedCells.Count; i += 4)
            {
                using (var command = new SqlCommand("INSERT into ClientRezervare(IDClient, IDRezervare) " +
                                                " values(" +
                                                " @id_client, " +
                                                " @id_rezervare)", conn))
                {
                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(new SqlParameter { ParameterName = "@id_client", Value = clientiGrid.SelectedCells[i].Value });
                    sqlParameters.Add(new SqlParameter { ParameterName = "@id_rezervare", Value = lastID });
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
                        return;
                    }
                }

            }
            MessageBox.Show("Rezervare efectuata cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
