using System;
using System.Collections.Generic;
using Scrapers;

namespace OutputTable
{
public class BioMass
{
  public static void Bio(TableData mainTable, FuelData bioTable)
  {
    ScrapeHelper.IterAndAddNode(mainTable.Tables[15].Descendants("tr"), mainTable.BiomassTable);
    // BIOTABLE
    //dt[0] title
    //dt[1] css (bad)
    //dt [2]+ is data for each plant
    bioTable.FuelTitle = mainTable.BiomassTable[0].InnerText;
    mainTable.BiomassTable.RemoveRange(0, 2);
    ScrapeHelper.LoopToFinal(mainTable.BiomassTable, bioTable.DataList);
  }
}
}