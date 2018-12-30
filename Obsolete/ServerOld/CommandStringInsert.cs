using System;
using Npgsql;
using NpgsqlTypes;
using Scrape;
using Scrapers;
using System.Collections.Generic;
using ConnectSecret;

namespace Psql
{
class MainTableInsert
        {
// Insert new record to tb_music.
public static void insertMainTable(Int64 id)
{
    // Open the connection to the psqlDb
    using (var conn = new NpgsqlConnection(ConnectToNpgSQL.GetConnection()))
    try
    {
        conn.Open();
        // Console.WriteLine("Connection Initilized");
        // Create insert command.
        NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
            $"maintable(id) VALUES(:id)", conn);
        // Add paramaters.
        command.Parameters.Add(new NpgsqlParameter("id",
            NpgsqlTypes.NpgsqlDbType.Bigint));

        // Prepare the command.
        command.Prepare();

        // Add value to the paramater.
        command.Parameters[0].Value = id;


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