using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.Text.RegularExpressions;
using Scrapers;
using OutputTable;
namespace Primary
{
    public class Program 
    {
        public static void Main(string[] args) 
        {
            ScrapeData EtsAeso = new ScrapeData();
            TempScrapeData TmpScrapeData = new TempScrapeData();
            TableData mainTable = new TableData();
            FuelData bioTable = new FuelData();

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
            BioMass.Bio(mainTable, bioTable);
        }
    }
}