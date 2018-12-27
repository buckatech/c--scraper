using System;
using Scrapers;
using Scrape;
namespace Primary
{
  public class Program 
    {
        public static void Main(string[] args) 
        {
            FuelData bioTable = new FuelData();
            FuelData windTable = new FuelData();
            FuelData hydroTable = new FuelData();
            FuelData coalTable = new FuelData();
            FuelData gasTable = new FuelData();
            ScrapeToMain.ScrapeOut(bioTable, windTable, hydroTable, coalTable, gasTable);
            foreach (var item in gasTable.DataList)
            {
                Console.WriteLine(item);
            }
        }
    }
}