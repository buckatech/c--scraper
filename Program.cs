using System;
using Scrapers;
using Scrape;
using Psql;
using System.Collections.Generic;
namespace Primary
{
  public class Program 
    {
        public static void Main(string[] args) 
        {
            DateTime centuryBegin = new DateTime(2001, 1, 1);
            DateTime currentDate = DateTime.Now;
            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            FuelData bioTable = new FuelData();
            FuelData windTable = new FuelData();
            FuelData hydroTable = new FuelData();
            FuelData coalTable = new FuelData();
            FuelData gasTable = new FuelData();
            ScrapeToMain.ScrapeOut(bioTable, windTable, hydroTable, coalTable, gasTable);
            // MainTableInsert.insertMainTable(elapsedTicks);
            foreach (var item in bioTable.DataList)
            {
                // Test.insertRecord("biotable", elapsedTicks, item.Asset, item.Mc, item.Tng, item.Dcr);
            }
            foreach (var item in windTable.DataList)
            {
                // Test.insertRecord("windtable", item.Asset, item.Mc, item.Tng, item.Dcr);
            }
            foreach (var item in hydroTable.DataList)
            {
                // Test.insertRecord("hydrotable", item.Asset, item.Mc, item.Tng, item.Dcr);
            }
            foreach (var item in coalTable.DataList)
            {
                // Test.insertRecord("coaltable", item.Asset, item.Mc, item.Tng, item.Dcr);
            }
            foreach (var item in gasTable.DataList)
            {
                // Test.insertRecord("gastable", item.Asset, item.Mc, item.Tng, item.Dcr);
            }
            // foreach (var item in hydroTable.DataList)
            // {
            //     Console.WriteLine(item.Mc);
            // }
        }
    }
}