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
    }
}
