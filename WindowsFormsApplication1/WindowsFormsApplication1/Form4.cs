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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            string sql = "INSERT INTO players(PLAYERID,PLAYERNAME,DOB,LOCID,GOALSCORED,ASSISTS,SAVES,TEAMID,SPONSORID)  VALUES('" + p1.Text + "','" + p2.Text + "','" + p3.Text + "','" + p4.Text + "','" + p5.Text + "','" + p6.Text + "','" + p7.Text + "','" + p8.Text + "','" + p9.Text +"')";
       
            db.insertinfo(ADD_PLAYER_INFO, sql);
            
        }

         
    
public  Button ADD_PLAYER_INFO { get; set; }

private void button2_Click(object sender, EventArgs e)
{
    Form3 f = new Form3();
    f.Show();
    this.Hide();
}

private void button5_Click(object sender, EventArgs e)
{
    DataBaseConnection db = new DataBaseConnection();
    OracleConnection ora_conn = new OracleConnection(db.getConStr());

    string table_name = "players";
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

        p1.Text = nextID;
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
