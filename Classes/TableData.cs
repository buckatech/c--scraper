using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace Scrapers
{
  public class TableData
  {
      public List<string> Title { get; set; }
      public List<HtmlNode> Tables { get; set; }
      public List<HtmlNode> DataTable { get; set; }
      public TableData()
      {
          Title = new List<string>();
          Tables = new List<HtmlNode>();
          DataTable = new List<HtmlNode>();
      }
  }
}