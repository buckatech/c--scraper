using System;
using System.Collections.Generic;
using HtmlAgilityPack;

using Scrapers;

namespace OutputTable
{
public class FormatGasData
{
  public static void FormatGas(TableData mainTable, int targetIndex, FuelData fuelTable, List<HtmlNode> currentTable)
  {
    ScrapeHelper.IterAndAddNode(mainTable.Tables[targetIndex].Descendants("tr"), currentTable);
    // fuelTable
    //dt[0] title
    //dt[1] css (bad)
    //dt [2]+ is data for each plant
    currentTable.RemoveRange(0, 3);
    currentTable.RemoveRange(27, 2);
    currentTable.RemoveRange(60, 2);
    fuelTable.FuelTitle = currentTable[0].InnerText;
    ScrapeHelper.LoopToFinal(currentTable, fuelTable.DataList);
  }
}
}