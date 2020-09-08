using Oracle.ManagedDataAccess.Client;
using System;

namespace QuePAT
{
    partial class QuePATDataBase
    {
        public void Query()
        {
            try
            {
                string querySqlStr = "SELECT * FROM province";
                Console.WriteLine(querySqlStr);
                try
                {
                    OracleCommand cmd = new OracleCommand(querySqlStr, conn);
                    Console.WriteLine("code\tname");
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine
                                (
                                    "{0}\t{1}",
                                    dr.GetValue(0).ToString(),
                                    dr.GetValue(1).ToString()
                                );
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
