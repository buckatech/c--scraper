using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;

namespace Scouter.Classes.ScrapeHandler
{
    public class AesoServerHandler
    {
        private HtmlWeb WebHtml = new HtmlWeb();
        public List<HtmlNode> ScrapedHtml;
        public AesoServerHandler()
        {
            ScrapedHtml = WebHtml.Load(@"http://ets.aeso.ca/ets_web/ip/Market/Reports/CSDReportServlet").DocumentNode.QuerySelectorAll("body").ToList();
        }
    }
}