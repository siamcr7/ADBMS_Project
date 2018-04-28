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
    public partial class Report_Form : Form
    {
        public Report_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            OracleConnection ora_conn = new OracleConnection(db.getConStr());

            string team_name = textBox1.Text;
    
            try
            {
                ora_conn.Open();

                /*********************Oracle Command**********************************************************************/
                OracleCommand ora_cmd = new OracleCommand("findTopPlayerOfTeam", ora_conn);
                ora_cmd.BindByName = true;
                ora_cmd.CommandType = CommandType.StoredProcedure;

                ora_cmd.Parameters.Add("team_name", OracleDbType.Varchar2, team_name, ParameterDirection.Input);
                ora_cmd.Parameters.Add("player_name", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                ora_cmd.Parameters.Add("goal_scored", OracleDbType.Decimal, ParameterDirection.Output);
                /*********************Oracle Command**********************************************************************/

                ora_cmd.ExecuteNonQuery();

                //Now get the values output by the stored procedure    
                string player_name = ora_cmd.Parameters["player_name"].Value.ToString();
                string goal_scored = ora_cmd.Parameters["goal_scored"].Value.ToString();


                MessageBox.Show( String.Format("Player name: {0}\nGoals: {1}", player_name, goal_scored));
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
            DataBaseConnection db = new DataBaseConnection();
            OracleConnection ora_conn = new OracleConnection(db.getConStr());

            string pos_name = textBox2.Text;

            try
            {
                ora_conn.Open();

                /*********************Oracle Command**********************************************************************/
                OracleCommand ora_cmd = new OracleCommand("pack_report.findBestPlayerPosProc", ora_conn);
                ora_cmd.BindByName = true;
                ora_cmd.CommandType = CommandType.StoredProcedure;

                ora_cmd.Parameters.Add("pos_name", OracleDbType.Varchar2, pos_name, ParameterDirection.Input);
                ora_cmd.Parameters.Add("player_name", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                ora_cmd.Parameters.Add("goal_scored", OracleDbType.Decimal, ParameterDirection.Output);
                ora_cmd.Parameters.Add("assists", OracleDbType.Decimal, ParameterDirection.Output);
                ora_cmd.Parameters.Add("saves", OracleDbType.Decimal, ParameterDirection.Output);
                /*********************Oracle Command**********************************************************************/

                ora_cmd.ExecuteNonQuery();

                //Now get the values output by the stored procedure    
                string player_name = ora_cmd.Parameters["player_name"].Value.ToString();
                string goal_scored = ora_cmd.Parameters["goal_scored"].Value.ToString();
                string assists = ora_cmd.Parameters["assists"].Value.ToString();
                string saves = ora_cmd.Parameters["saves"].Value.ToString();

                MessageBox.Show(String.Format("Player name: {0}\nGoals: {1} \nAssists:{2} \nSaves: {3}", player_name, goal_scored, assists, saves));
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

        private void button3_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            OracleConnection ora_conn = new OracleConnection(db.getConStr());

            try
            {
                ora_conn.Open();

                /*********************Oracle Command**********************************************************************/
                OracleCommand ora_cmd = new OracleCommand("pack_report.seeStandingsProc", ora_conn);
                ora_cmd.BindByName = true;
                ora_cmd.CommandType = CommandType.StoredProcedure;


                ora_cmd.Parameters.Add("team_name", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                ora_cmd.Parameters.Add("points", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                /*********************Oracle Command**********************************************************************/

                ora_cmd.ExecuteNonQuery();

                //Now get the values output by the stored procedure    
                string team_name = ora_cmd.Parameters["team_name"].Value.ToString();
                string points = ora_cmd.Parameters["points"].Value.ToString();

                string[] tokensName = team_name.Split(',');
                string[] tokensPoints = points.Split(',');

                string ret = "";
                for (int i = 0; i < tokensName.Length-1; i++)
                {
                    ret += "Team Name: ";
                    ret += (tokensName[i].Trim());
                    ret += "\t Points: ";
                    ret += tokensPoints[i].Trim();
                    ret += "\n";
                }

                MessageBox.Show(ret);
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            OracleConnection ora_conn = new OracleConnection(db.getConStr());

            string table_name = "coaches";
            MessageBox.Show(db.getConStr());
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

                MessageBox.Show(nextID);

                textBox1.Text = nextID;
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
    }
}
