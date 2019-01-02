using System;
using Scouter.Classes.MainData;
using Scouter.Classes.DataToSql;
using System.Collections.Generic;
namespace Scouter.Classes
{
    public class ServerHandler
    {
        public void SelectFromServer(long pk)
        {
            var selectx = new SelectFromServer();
            selectx.SelectMain(pk);

            Console.WriteLine("fired");
        }
        public long InsertToMainServer()
        {


            GetData Data = new GetData();
            Dictionary<string, string> summary = Data.SummaryData;
            Dictionary<string, string> interchange = Data.InterchangeData;
            Dictionary<string, List<string>> coal = Data.CoalData;
            Dictionary<string, List<string>> wind = Data.WindData;
            Dictionary<string, List<string>> biomass = Data.BiomassData;
            Dictionary<string, List<string>> hydro = Data.HydroData;
            List<Dictionary<string, List<string>>> gas = Data.GasData;

            long currentTime = DateTime.Now.Ticks;

            InsertToServer db = new InsertToServer();

            SelectFromServer selectDb = new SelectFromServer();

            DataUtilities util = new DataUtilities();
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
            foreach (KeyValuePair<string, string> entry in interchange)
            {
                db.InsertSummary("interchange_table", pK, entry.Key, entry.Value);
            }
            for (int i = 0; i < gas.Count; i++)
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
            return pK;
        }
    }
}
