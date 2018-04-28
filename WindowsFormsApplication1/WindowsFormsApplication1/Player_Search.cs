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
    public partial class Player_Search : Form
    {
        public Player_Search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            string player_name = "";
            string team_name = "";
            string owener_name = "";
            string kitcolor = "";
            string sponsor_name = "";
            string location_name = "";

            string minGoals = "";
            string maxGoals = "";
            string minAssists = "";
            string maxAssists = "";
            string minSaves = "";
            string maxSaves = "";
            string minDOB = "";
            string maxDOB = "";

    
            /// LOAD ALL
            player_name = textBox1.Text;
            team_name = textBox2.Text;
            owener_name = textBox3.Text;
            sponsor_name = textBox4.Text;
            kitcolor = textBox5.Text;
            location_name = textBox6.Text;


            minGoals = textBox7.Text;
            maxGoals = textBox8.Text;
            minAssists = textBox9.Text;
            maxAssists = textBox10.Text;
            minSaves = textBox11.Text;
            maxSaves = textBox12.Text;


            if (minGoals == "") minGoals = "0";
            if (minAssists == "") minAssists = "0";
            if (minSaves == "") minSaves = "0";

            if (maxGoals == "") maxGoals = "100000";
            if (maxAssists == "") maxAssists = "100000";
            if (maxSaves == "") maxSaves = "100000";

            string sql =
@"select * from players
where
playername like '%" + player_name + @"%'
and 
teamid in 
(
	select teamid from teams
	where 
	teamname like '%" + team_name + @"%'
	and
	ownerid in
	(
		select ownerid from owners
		where ownername like '%" + owener_name + @"%'
	)
	and 
	kitid in
	(
		select kitid from kits
		where kitcolor like '%" + kitcolor + @"%'
	)
)
and
sponsorid in
(
	select sponsorid from sponsors
	where 
	sponsorname like '%" + sponsor_name + @"%'
)
and
locid in
(
	select locid from locations
	where 
	loc like '%" + location_name + @"%'
)
and 
nvl(goalscored,0) between " + minGoals + " and "+ maxGoals + @"
and 
nvl(saves,0) between " + minSaves + " and " + maxSaves + @"
and 
nvl(assists,0) between " + minAssists + " and " + maxAssists + @"
";
         db.selectQueryGridView(dataGridView1, sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
