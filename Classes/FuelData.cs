using System;
using System.Collections.Generic;


namespace Scrapers
{
  public class FuelData
    {
        // Auto-implemented readonly property:
        public string FuelTitle { get; set; }
        public List<McTngDcr> DataList { get; set; }    
        public FuelData()
        {
            DataList = new List<McTngDcr>();
        }
    }
}