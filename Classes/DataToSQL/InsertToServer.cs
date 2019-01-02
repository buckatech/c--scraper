using System;
using Npgsql;
using NpgsqlTypes;
using System.Collections.Generic;
using ConnectSecret;

namespace Scouter.Classes.DataToSql
{
    class InsertToServer
    {
        public long InsertMain(string targetTable, long timeStamp)
        {
            // Open the connection to the psqlDb
            using (var conn = new NpgsqlConnection(ConnectToNpgSQL.GetConnection()))
                try
                {
                    conn.Open();
                    // Console.WriteLine("Connection Initilized");
                    // Create insert command.
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                        $"{targetTable}(time_stamp) VALUES(:time_stamp) returning *;", conn);
                    // Add paramaters.
                    command.Parameters.Add(new NpgsqlParameter("time_stamp",
                        NpgsqlTypes.NpgsqlDbType.Bigint));
                    // Prepare the command.
                    command.Prepare();

                    // Add value to the paramater.
                    command.Parameters[0].Value = timeStamp;

                    // Execute SQL command.
                    var recordAffected = command.ExecuteScalar();
                    if (Convert.ToBoolean(recordAffected))
                    {
                        return Convert.ToInt64(recordAffected);
                    }

                    conn.Close();
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine(ex);
                    long err = 0;
                    return err;
                }
            return 0;
        }
        public void InsertSummary(string targetTable, long pk, string name, string value)
        {
            // Open the connection to the psqlDb
            using (var conn = new NpgsqlConnection(ConnectToNpgSQL.GetConnection()))
                try
                {
                    conn.Open();
                    // Console.WriteLine("Connection Initilized");
                    // Create insert command.
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                        $"{targetTable}(main_table_id, name, value) VALUES(:main_table_id, :name, :value)", conn);
                    // Add paramaters.
                    command.Parameters.Add(new NpgsqlParameter("main_table_id",
                        NpgsqlTypes.NpgsqlDbType.Bigint));
                    command.Parameters.Add(new NpgsqlParameter("name",
                        NpgsqlTypes.NpgsqlDbType.Text));
                    command.Parameters.Add(new NpgsqlParameter("value",
                        NpgsqlTypes.NpgsqlDbType.Text));

                    // Prepare the command.
                    command.Prepare();

                    // Add value to the paramater.
                    command.Parameters[0].Value = pk;
                    command.Parameters[1].Value = name;
                    command.Parameters[2].Value = value;

                    // Execute SQL command.
                    int recordAffected = command.ExecuteNonQuery();
                    if (Convert.ToBoolean(recordAffected))
                    {
                        // Console.WriteLine("Data successfully saved!");
                    }

                    conn.Close();
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine(ex);
                }
        }
        // Insert new record to tb_music.
        public void InsertFuelRecord(string targetTable, long pk, string asset, string mc, string tng, string dcr)
        {
            // Open the connection to the psqlDb
            using (var conn = new NpgsqlConnection(ConnectToNpgSQL.GetConnection()))
                try
                {
                    conn.Open();
                    // Console.WriteLine("Connection Initilized");
                    // Create insert command.
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                        $"{targetTable}(main_table_id, asset, mc, tng, dcr) VALUES(:main_table_id, :asset, :mc, " +
                        ":tng, :dcr)", conn);
                    // Add paramaters.
                    command.Parameters.Add(new NpgsqlParameter("main_table_id",
                        NpgsqlTypes.NpgsqlDbType.Bigint));
                    command.Parameters.Add(new NpgsqlParameter("asset",
                        NpgsqlTypes.NpgsqlDbType.Text));
                    command.Parameters.Add(new NpgsqlParameter("mc",
                        NpgsqlTypes.NpgsqlDbType.Text));
                    command.Parameters.Add(new NpgsqlParameter("tng",
                        NpgsqlTypes.NpgsqlDbType.Text));
                    command.Parameters.Add(new NpgsqlParameter("dcr",
                        NpgsqlTypes.NpgsqlDbType.Text));

                    // Prepare the command.
                    command.Prepare();

                    // Add value to the paramater.
                    command.Parameters[0].Value = pk;
                    command.Parameters[1].Value = asset;
                    command.Parameters[2].Value = mc;
                    command.Parameters[3].Value = tng;
                    command.Parameters[4].Value = dcr;

                    // Execute SQL command.
                    int recordAffected = command.ExecuteNonQuery();
                    if (Convert.ToBoolean(recordAffected))
                    {
                        // Console.WriteLine("Data successfully saved!");
                    }

                    conn.Close();
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine(ex);
                }
        }
    }
}