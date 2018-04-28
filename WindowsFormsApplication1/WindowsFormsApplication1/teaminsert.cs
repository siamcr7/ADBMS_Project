using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApplication1
{
    public partial class teaminsert : Form
    {
        public teaminsert()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            string sql = "INSERT INTO TEAMS(TEAMID,TEAMNAME,STADIUMID,COACHID,GAMEPLAYED,GAMEWON,GAMELOST,GAMEDRAWN,SPONSORID,KITID,OWNERID)  VALUES('" + k1.Text + "','" + k2.Text + "','" + k3.Text + "','" + k4.Text + "','" + k5.Text + "','" + k6.Text + "','" + k7.Text + "','" + k9.Text + "','" + k10.Text + "','" + k11.Text + "','" + k11.Text + "')";

            db.insertinfo(Insert, sql);
        }

        public Button Insert { get; set; }

        private void button5_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            OracleConnection ora_conn = new OracleConnection(db.getConStr());

            string table_name = "teams";
            try
            {
                ora_conn.Open();

                /*********************Oracle Command**********************************************************************/
                OracleCommand ora_cmd = new OracleCommand("getNextID", ora_conn);
                ora_cmd.BindByName = true;
                ora_cmd.CommandType = CommandType.StoredProcedure;

                ora_cmd.Parameters.Add("table_name", OracleDbType.Varchar2, table_name, ParameterDirection.Input);
                ora_cmd.Parameters.Add("nextID", OracleDbType.Int32, ParameterDirection.Output);
                /*********************Oracle Command**********************************************************************/

                ora_cmd.ExecuteNonQuery();

                //Now get the values output by the stored procedure    
                string nextID = ora_cmd.Parameters["nextID"].Value.ToString();

                k1.Text = nextID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (ora_conn.State == ConnectionState.Open)
                {
                    ora_conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
