using System;
using Newtonsoft.Json;
using Scouter.Classes.PublicEndpoint;
using System.Collections.Generic;
using System.Collections;
using Scouter.Classes.MainData;

namespace Scouter.Classes.PublicEndpoint
{
    public class DataToJson
    {
        public void OutputJson()
        {
            var data = new GetData();
            var coal = data.CoalData;
            var hydro = data.HydroData;
            var wind = data.WindData;
            var biomass = data.BiomassData;
            var gas = data.GasData;
            var interchange = data.InterchangeData;
            var summary = data.SummaryData;
            var dataTable = new Hashtable
            {
                { "summary", summary },
                { "interchange", interchange},
                { "coal", coal },
                { "hydro", hydro },
                { "wind", wind },
                { "biomass", biomass }
            };
            for (int i = 0; i < gas.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        dataTable.Add("simple", gas[i]);
                        break;
                    case 1:
                        dataTable.Add("cogeneration", gas[i]);
                        break;
                    case 2:
                        dataTable.Add("combined", gas[i]);
                        break;

                }
            }
            string output = JsonConvert.SerializeObject(dataTable);
            Console.WriteLine(output);
        }
    }
}
