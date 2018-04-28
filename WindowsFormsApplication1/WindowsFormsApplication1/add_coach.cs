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
    public partial class add_coach : Form
    {
        public add_coach()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            string sql = "INSERT INTO COACHES(COACHID,COACHNAME,LOCID) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" +null+ "')";
            db.insertinfo(ADD, sql);
        }

        public Button ADD { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            coach c = new coach();
            c.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            OracleConnection ora_conn = new OracleConnection(db.getConStr());

            string table_name = "coaches";
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

        private void add_coach_Load(object sender, EventArgs e)
        {

        }
    }
}
