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

    public partial class Form1 : Form
    {
        //string conStr = "Data Source=localhost:1521/XE; User Id=asir1; Password=asir1;";
        // Query
        //string sql = "SELECT * FROM users";
        /*
        private DataSet ds;
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
         * */

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
  
        }

        private void button1_Click(object sender, EventArgs e)
        {

           insertion f=new insertion();
           f.Show();
           this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DataBaseConnection db = new DataBaseConnection();
            string sql = "select * from USERS";
            db.selectQueryGridView(gridv, sql);

        }


        private void button3_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            string sql = "select user_name from USERS";
            db.selectQueryGridView(dataGridView1, sql);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dltmembr d = new dltmembr();
            d.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            login lg = new login();
            lg.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM USERS where user_name like ('%" + text1.Text + "%')";
            DataBaseConnection db = new DataBaseConnection();
            db.loginmember(find, sql);
            db.selectQueryGridView(grit, sql);

        }

        public Button find { get; set; }

        private void button9_Click(object sender, EventArgs e)
        {
          
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            coach n = new coach();
            n.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Player_Search ps = new Player_Search();
            ps.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Report_Form rf = new Report_Form();
            rf.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            teaminsert ti = new teaminsert();
            ti.Show();
        }
    }
}
