using System;
using Npgsql;
using ConnectSecret;

namespace Scouter.Classes.DataToSql
{
    class DataUtilities
    {
        public void DbMigrate()
        {
            NpgsqlConnection conn = null;
            using (conn = new NpgsqlConnection(ConnectToNpgSQL.GetConnection()))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(
                "DROP TABLE IF EXISTS main_table, coal_table, hydro_table, wind_table, biomass_table, interchange_table, summary_table, simple_cycle_table, cogeneration_table, combined_cycle_table; " +
                "CREATE TABLE main_table(id SERIAL, time_stamp BIGINT);" +
                "CREATE TABLE coal_table(id SERIAL, main_table_id INTEGER, asset TEXT, mc TEXT, tng TEXT, dcr TEXT); " +
                "CREATE TABLE hydro_table(id SERIAL, main_table_id INTEGER, asset TEXT, mc TEXT, tng TEXT, dcr TEXT);" +
                "CREATE TABLE wind_table(id SERIAL, main_table_id INTEGER, asset TEXT, mc TEXT, tng TEXT, dcr TEXT);" +
                "CREATE TABLE biomass_table(id SERIAL, main_table_id INTEGER, asset TEXT, mc TEXT, tng TEXT, dcr TEXT);" +
                "CREATE TABLE simple_cycle_table(id SERIAL, main_table_id INTEGER, asset TEXT, mc TEXT, tng TEXT, dcr TEXT);" +
                "CREATE TABLE cogeneration_table(id SERIAL, main_table_id INTEGER, asset TEXT, mc TEXT, tng TEXT, dcr TEXT);" +
                "CREATE TABLE combined_cycle_table(id SERIAL, main_table_id INTEGER, asset TEXT, mc TEXT, tng TEXT, dcr TEXT);" +
                "CREATE TABLE summary_table(id SERIAL, main_table_id INTEGER, name TEXT, value TEXT);" +
                "CREATE TABLE interchange_table(id SERIAL, main_table_id INTEGER, name TEXT, value TEXT);",
                conn))
                    cmd.ExecuteNonQuery();
                Console.WriteLine("Migration success");
            }
        }
    }
}
