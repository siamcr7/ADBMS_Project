﻿using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            string sql = "update users set user_name=('" + up1.Text + "') where user_id = ('" + up2.Text + "')";
            db.updater(update,sql);
        }

        public Button update { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();
            string sql = "update users set password=('" + t2.Text + "') where user_id = ('" + t1.Text + "')";
            db.updater(Changepassword, sql);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public Button Changepassword { get; set; }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
