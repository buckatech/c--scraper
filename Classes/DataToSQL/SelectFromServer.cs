using System;
using Npgsql;
using ConnectSecret;

namespace Scouter.Classes.DataToSql
{
    public class SelectFromServer
    {
        public void SelectMain()
        {
            // Open the connection to the psqlDb
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectToNpgSQL.GetConnection()))
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT asset FROM coal_table WHERE main_table_id = 1", conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        while (reader.Read())
                            Console.WriteLine(reader.GetString(0));

                    conn.Close();
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine(ex);
                    long err = 0;
                    Console.WriteLine(err);
                }

        }
    }
}
