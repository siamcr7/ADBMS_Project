using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;


namespace WindowsFormsApplication1
{
     class Program : Form1
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new login());
            //Application.Run(new Report_Form());
            //Application.Run(new Player_Search());
        }
    }
}
