using System;
using Npgsql;
using NpgsqlTypes;
using Scrape;
using Scrapers;
using System.Collections.Generic;


namespace ConnectSecret
{
class ConnectToNpgSQL
{
  public static string GetConnection()
  {
    {
      // To avoid storing the connection string in your code, 
      // you can retrieve it from a configuration file.
      return "Server=127.0.0.1;User Id=bubbles; " + 
          "Password=bubbles123;Database=cstest;";
    }
  }
}
}