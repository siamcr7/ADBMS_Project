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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            string sql = "update players set PLAYERNAME ='" + box2.Text + "' where PLAYERID = " + box1.Text + "";
            db.updater(UPDATENAME, sql);
        }

        public Button UPDATENAME { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            string sql = "update players set GOALSCORED=('" + box4.Text + "') where PLAYERID = " + box3.Text + "";
            db.updater(UPDATEID, sql);
        }


        public Button UPDATEID { get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
    }
}
