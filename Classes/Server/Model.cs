using System;
using Npgsql;
using NpgsqlTypes;
using Scrape;
using Scrapers;
using System.Collections.Generic;


namespace Psql
{
class Test
        {
// Insert new record to tb_music.
public static void insertRecord(String targetTable, String asset, String mc, String tng, String dcr)
{
    // Open the connection to the psqlDb
    using (var conn = new NpgsqlConnection(GetConnectionString()))
    try
    {
        conn.Open();
        // Console.WriteLine("Connection Initilized");
        // Create insert command.
        NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
            $"{targetTable}(asset, mc, tng, dcr) VALUES(:asset, :mc, " +
            ":tng, :dcr)", conn);
        // Add paramaters.
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
        command.Parameters[0].Value = asset;
        command.Parameters[1].Value = mc;
        command.Parameters[2].Value = tng;
        command.Parameters[3].Value = dcr;

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
        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file.
            return "Server=127.0.0.1;User Id=bubbles; " + 
                "Password=bubbles123;Database=cstest;";
        }
    }
}