using System;
using Scouter.Classes.MainData;
using Scouter.Classes.DataToSql;
using System.Collections.Generic;
namespace Primary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Data = new GetData();
            var coal = Data.CoalData;
            var wind = Data.WindData;
            var biomass = Data.BiomassData;
            var hydro = Data.HydroData;
            var summary = Data.SummaryData;
            var gas = Data.GasData;
            var interchange = Data.InterchangeData;
            long currentTime = DateTime.Now.Ticks;
            var db = new InsertToServer();
            var util = new DataUtilities();
            util.DbMigrate();
            long pK = db.InsertMain("main_table", currentTime);
            if (pK > 0)
            {
                Console.WriteLine(pK);
            }
            else
            {
                Console.WriteLine("FAIL FAIL FAIL");
            }
            foreach (KeyValuePair<string, List<string>> entry in coal)
            {
                db.InsertFuelRecord("coal_table", pK, entry.Key, entry.Value[0], entry.Value[1], entry.Value[2]);
            }
            foreach (KeyValuePair<string, List<string>> entry in wind)
            {
                db.InsertFuelRecord("wind_table", pK, entry.Key, entry.Value[0], entry.Value[1], entry.Value[2]);
            }
            foreach (KeyValuePair<string, List<string>> entry in hydro)
            {
                db.InsertFuelRecord("hydro_table", pK, entry.Key, entry.Value[0], entry.Value[1], entry.Value[2]);
            }
            foreach (KeyValuePair<string, List<string>> entry in biomass)
            {
                db.InsertFuelRecord("biomass_table", pK, entry.Key, entry.Value[0], entry.Value[1], entry.Value[2]);
            }
            foreach (KeyValuePair<string, string> entry in summary)
            {
                db.InsertSummary("summary_table", pK, entry.Key, entry.Value);
            }
            foreach(KeyValuePair<string, string> entry in interchange)
            {
                db.InsertSummary("interchange_table", pK, entry.Key, entry.Value);
            }
            for (var i = 0; i < gas.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        foreach (KeyValuePair<string, List<string>> entry in gas[i])
                        {
                            db.InsertFuelRecord("simple_cycle_table", pK, entry.Key, entry.Value[0], entry.Value[1], entry.Value[2]);
                        }
                        break;
                    case 1:
                        foreach (KeyValuePair<string, List<string>> entry in gas[i])
                        {
                            db.InsertFuelRecord("cogeneration_table", pK, entry.Key, entry.Value[0], entry.Value[1], entry.Value[2]);
                        }
                        break;
                    case 2:
                        foreach (KeyValuePair<string, List<string>> entry in gas[i])
                        {
                            db.InsertFuelRecord("combined_cycle_table", pK, entry.Key, entry.Value[0], entry.Value[1], entry.Value[2]);
                        }
                        break;

                }
            }
        }
    }
}
