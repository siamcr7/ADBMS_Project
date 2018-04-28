using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;


namespace WindowsFormsApplication1
{
    public class Program : Form1
    {
     
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new login());
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(975, 561);
            this.Name = "Program";
            this.Load += new System.EventHandler(this.Program_Load);
            this.ResumeLayout(false);

        }

    

        public void button7_Click_1(object sender, EventArgs e)
        {

        }

        public void Program_Load(object sender, EventArgs e)
        {

        }
    }
}
