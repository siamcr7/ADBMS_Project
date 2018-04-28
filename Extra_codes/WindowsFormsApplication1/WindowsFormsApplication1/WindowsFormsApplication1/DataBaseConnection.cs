using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    class DataBaseConnection
    {
        private string conStr;
        private string userName = "jamil";
        private string password = "jamil";
        public static bool condition=false;
        public DataBaseConnection()
        {
            // Creating connection string
            this.conStr = "Data Source=localhost:1521/XE; User Id=" + this.userName
                + "; Password=" + this.password + ";";
        }

        public string getConStr()
        {
            return this.conStr;
        }

        public void insertinfo(Button RegisterMember, string sql)
        {

            //ensure the connection is set
            OracleConnection con = new OracleConnection(conStr);



            using (OracleConnection conn = new OracleConnection(conStr))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(sql, con))
                {
                    string commandText = sql;
                    cmd.Connection = conn;
                    cmd.CommandText = commandText;
                    try
                    {
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("User Successfully Created");
                        }
                        else
                        {
                            MessageBox.Show("Failed to Create User");
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);

                    }
                    finally
                    {

                        conn.Close();
                    }

                }



            }
        }

        public void selectQueryGridView(DataGridView gridv, string sql)
        {
            OracleConnection con = new OracleConnection(conStr);
            OracleCommand cmd = new OracleCommand(sql, con);
            cmd = new OracleCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            OracleCommandBuilder cb = new OracleCommandBuilder(da);
            DataSet ds = new DataSet();

            da.Fill(ds);

            gridv.DataSource = ds.Tables[0];
            da.Fill(dt);
            return;
        }
        public void loginmember(Button login,string sql)
        {

            OracleConnection conn = new OracleConnection(conStr);

            using (OracleDataAdapter adap = new OracleDataAdapter(sql, conn))
            {
                DataTable dat = new DataTable();
                adap.Fill(dat);
                if (dat.Rows.Count == 1)
                {
                    MessageBox.Show("Welcome!");
                    condition = true;
                  
                }
                else
                {
                    MessageBox.Show("Oops!please provide correct user info!");
                    condition = false;
                }
            }
        }

        public void deletemembr(Button delete,String sql)
        {
            OracleConnection con = new OracleConnection(conStr);



            using (OracleConnection conn = new OracleConnection(conStr))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    string commandText = sql;
                    cmd.Connection = conn;
                    cmd.CommandText = commandText;
                    try
                    {
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Successfully deleted");
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete");
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);

                    }
                    finally
                    {

                        conn.Close();
                    }
                }
            }


        }
        public void updater(Button z, String sql)
        {
            OracleConnection con = new OracleConnection(conStr);



            using (OracleConnection conn = new OracleConnection(conStr))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    string commandText = sql;
                    cmd.Connection = conn;
                    cmd.CommandText = commandText;
                    try
                    {
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Successfully Updated");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update");
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);

                    }
                    finally
                    {

                        conn.Close();
                    }
                }
            }


        }

    }
}
