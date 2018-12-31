using System.Collections.Generic;
using Scouter.Classes.ScrapeHandler;
using HtmlAgilityPack;
namespace Scouter.Classes.DataFormatters
{
    public class SplitTargetToStruct
    {
        public List<HtmlNode> test = new AesoDataFormatter().TargetNodes();

        // Splits each relevent List entity into a dictionary
        public Dictionary<string, HtmlNode> SplitToCategories(List<HtmlNode> targHtml)
        {
            Dictionary<string, HtmlNode> nodeDictionary =
                new Dictionary<string, HtmlNode>();
            int countLen = targHtml.Count;
            for (var i = 0; i < countLen; i++)
            {
                /* RELEVENT TABLES
                 i = [3] Contains timestamp
                 i = [5] Contains summary
                 i = [6] Contains total table
                 i = [7] Contains interchange Data               
                 i = [10] Contains coal
                 i = [11] Contains gas
                 i = [13] Contains hydro
                 i = [14] Contains wind
                 i = [15] Contains biomass
                */
                switch (i)
                {
                    case 3:
                        nodeDictionary.Add("TimeStamp", targHtml[i]);
                        break;
                    case 5:
                        nodeDictionary.Add("Summary", targHtml[i]);
                        break;
                    case 6:
                        nodeDictionary.Add("TotalTable", targHtml[i]);
                        break;
                    case 7:
                        nodeDictionary.Add("InterchangeTable", targHtml[i]);
                        break;
                    case 10:
                        nodeDictionary.Add("Coal", targHtml[i]);
                        break;
                    case 11:
                        nodeDictionary.Add("Gas", targHtml[i]);
                        break;
                    case 13:
                        nodeDictionary.Add("Hydro", targHtml[i]);
                        break;
                    case 14:
                        nodeDictionary.Add("Wind", targHtml[i]);
                        break;
                    case 15:
                        nodeDictionary.Add("Biomass", targHtml[i]);
                        break;
                }
            }

            return nodeDictionary;
        }
    }
}