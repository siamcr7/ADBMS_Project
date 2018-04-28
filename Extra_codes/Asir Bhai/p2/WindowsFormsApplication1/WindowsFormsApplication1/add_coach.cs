using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
