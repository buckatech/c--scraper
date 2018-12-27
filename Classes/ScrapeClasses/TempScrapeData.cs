using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace Scrapers
{
  public class TempScrapeData
  {
      public List<HtmlNode> scrapeParts { get; set; }
      public TempScrapeData()
      {
          scrapeParts = new List<HtmlNode>();
      }
  }
}