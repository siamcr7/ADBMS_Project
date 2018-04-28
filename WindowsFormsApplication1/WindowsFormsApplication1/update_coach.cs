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
    public partial class update_coach : Form
    {
        public update_coach()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            string sql = "update COACHES set COACHNAME=('" + tes2.Text + "') where COACHID = ('" + tes1.Text + "')";
            db.updater(UPDATE_COACH, sql);
        }

        private void update_coach_Load(object sender, EventArgs e)
        {

        }

        public Button UPDATE_COACH { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            coach c = new coach();
            c.Show();
            this.Hide();
        }
    }
}
