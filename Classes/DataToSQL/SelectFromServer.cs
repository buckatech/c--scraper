using System;
using Npgsql;
using ConnectSecret;
using System.Collections.Generic;

namespace Scouter.Classes.DataToSql
{
    public class SelectFromServer
    {
        public void SelectMain(long id)
        {
            List<string> output = new List<string>();
            // Open the connection to the psqlDb
            using (var conn = new NpgsqlConnection(ConnectToNpgSQL.GetConnection()))
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand($"SELECT asset, mc FROM coal_table WHERE main_table_id = {id}", conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        while (reader.Read())
                            // Console.WriteLine(reader.GetString(0), reader.GetString(1));

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
