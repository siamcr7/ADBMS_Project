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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM USERS where user_name like ('" + tox1.Text + "') and password like ('" + tox2.Text + "')";
            DataBaseConnection db = new DataBaseConnection();
            db.loginmember(Login,sql);
            if (DataBaseConnection.condition==true)
            {
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
        }

        public Button Login { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            insertion f = new insertion();
            f.Show();
            this.Hide();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
