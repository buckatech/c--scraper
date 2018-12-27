using System;
using System.Collections.Generic;
using Fizzler.Systems.HtmlAgilityPack;

using HtmlAgilityPack;

namespace Scrapers
{
  public class ScrapeData
  {
      public string TargetUrl { get; set; }
      public HtmlWeb Hweb = new HtmlWeb();
      public HtmlDocument Hdoc()
      {
          return Hweb.Load(TargetUrl);
      }
      public IEnumerable<HtmlNode> BodyData()
      {
          return Hweb.Load(TargetUrl).DocumentNode.QuerySelectorAll("body");
      }
  }
}