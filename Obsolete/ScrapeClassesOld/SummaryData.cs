using System;
using System.Collections.Generic;
using HtmlAgilityPack;

using Scrapers;

namespace OutputTable
{
    public class FormatUtilityTable
    {
        public static void FormatUtility(TableData mainTable, int targetIndex, FuelData fuelTable, List<HtmlNode> currentTable)
        {
            ScrapeHelper.IterAndAddNode(mainTable.Tables[targetIndex].Descendants("tr"), currentTable);
            // fuelTable
            //dt[0] title
            //dt[1] css (bad)
            //dt [2]+ is data for each plant
            fuelTable.FuelTitle = currentTable[0].InnerText;
            currentTable.RemoveRange(0, 2);
            ScrapeHelper.LoopToFinal(currentTable, fuelTable.DataList);
        }
    }
}