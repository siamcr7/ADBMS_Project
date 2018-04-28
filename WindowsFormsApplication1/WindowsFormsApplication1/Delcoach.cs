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
    public partial class Delcoach : Form
    {
        public Delcoach()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            string sql = "DELETE FROM COACHES where COACHID like ('" + d1.Text + "') or COACHNAME like ('" + d2.Text + "')";
            db.deletemembr(delete_COACH, sql);
        }

        public Button delete_COACH { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            coach c = new coach();
            c.Show();
            this.Hide();
        }
    }
}
