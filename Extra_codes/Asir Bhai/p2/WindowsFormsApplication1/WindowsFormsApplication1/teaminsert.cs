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
    }
}
