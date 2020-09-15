using Oracle.ManagedDataAccess.Client;
using System;

namespace QuePAT
{
    partial class QuePATDataBase
    {
        public QuePATDataBase(string id, string password)
        {
            ConnectOracle(id, password);
        }

        ~QuePATDataBase()
        {
            DisconnectOracle();
        }

        public void ConnectOracle(string id, string password)
        {
            try
            {
                string conn_str =
                    "Data Source=" +
                    "(" +
                    "DESCRIPTION=" +
                    "(" +
                    "ADDRESS=" +
                    "(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)" +
                    ")" +
                    "(CONNECT_DATA=(SERVICE_NAME=orcl))" +
                    ");" +
                    "Persist Security Info=True;" +
                    "User ID=" + id + ";" +
                    "Password=" + password + ";";
                conn = new OracleConnection(conn_str);
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void DisconnectOracle()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private OracleConnection conn = null;
    }
}
