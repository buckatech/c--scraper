using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace Scrapers
{
public class TableData
{
    public List<HtmlNode> Tables { get; set; }
    public List<HtmlNode> BiomassTable { get; set; }
    public List<HtmlNode> WindTable { get; set; }
    public List<HtmlNode> HydroTable { get; set; }
    public List<HtmlNode> CoalTable { get; set; }
    public List<HtmlNode> GasTable { get; set; }
    
    public TableData()
    {
        Tables = new List<HtmlNode>();
        BiomassTable = new List<HtmlNode>();
        WindTable = new List<HtmlNode>();
        HydroTable = new List<HtmlNode>();
        CoalTable = new List<HtmlNode>();
        GasTable = new List<HtmlNode>();
    }
}
}