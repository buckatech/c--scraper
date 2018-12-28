using System;
using Npgsql;
using NpgsqlTypes;
using Scrape;
using Scrapers;
using System.Collections.Generic;
using ConnectSecret;

namespace Psql
{
class Test
        {
// Insert new record to tb_music.
public static void insertRecord(String targetTable, Int64 maintable_id, String asset, String mc, String tng, String dcr)
{
    // Open the connection to the psqlDb
    using (var conn = new NpgsqlConnection(ConnectToNpgSQL.GetConnection()))
    try
    {
        conn.Open();
        // Console.WriteLine("Connection Initilized");
        // Create insert command.
        NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
            $"{targetTable}(maintable_id, asset, mc, tng, dcr) VALUES(:maintable_id, :asset, :mc, " +
            ":tng, :dcr)", conn);
        // Add paramaters.
        command.Parameters.Add(new NpgsqlParameter("maintable_id",
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
        command.Parameters[0].Value = maintable_id;
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