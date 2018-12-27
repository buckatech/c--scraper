using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.Text.RegularExpressions;
using Scrapers;
using OutputTable;

namespace Scrape
{
    public class ScrapeToMain
    {
        public static void ScrapeOut(
          FuelData bioTable, 
          FuelData windTable, 
          FuelData hydroTable,
          FuelData coalTable,
          FuelData gasTable
          ) 
        {
            ScrapeData EtsAeso = new ScrapeData();
            TempScrapeData TmpScrapeData = new TempScrapeData();
            TableData mainTable = new TableData();
            EtsAeso.TargetUrl = @"http://ets.aeso.ca/ets_web/ip/Market/Reports/CSDReportServlet";
            ScrapeHelper.IterAndAddNode(EtsAeso.BodyData(), TmpScrapeData.scrapeParts);
            ScrapeHelper.IterAndAddNode(TmpScrapeData.scrapeParts[1].Descendants("table"), mainTable.Tables);
            // Tables[3] Contains timestamp
            // Tables[5] Contains summary
            // Tables[6] Contains total table
            // Tables[10] Contains coal table
            // Tables[11] Contains gas table
            // Tables[13] Contains hydro table
            // Tables[14] Contains wind table
            // Tables[15] Contains biomass and other table
            // Console.WriteLine(mainTable.Tables[11].InnerHtml);
            FormatFuelData.Format(mainTable, 10, coalTable, mainTable.CoalTable);
            FormatGasData.FormatGas(mainTable, 11, gasTable, mainTable.GasTable);  
            FormatFuelData.Format(mainTable, 13, hydroTable, mainTable.HydroTable);
            FormatFuelData.Format(mainTable, 14, windTable, mainTable.WindTable);            
            FormatFuelData.Format(mainTable, 15, bioTable, mainTable.BiomassTable);
        }
    }
}