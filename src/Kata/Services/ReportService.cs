using System;
using System.Linq;
using System.Collections.Generic;

namespace Kata
{
    public static class ReportService
    {
        public static Report CreateReport(IEnumerable<Driver> drivers)
        {
            List<string> Records = new List<string>();
            List<Trip> RelevantTrips;
            double totalDistance;
            double avgMph;
            string record;

            foreach (Driver driver in drivers)
            {
                totalDistance = 0;
                avgMph = 0;

                if (driver.Trips != null)
                {
                    RelevantTrips = driver.Trips.Where(x => x.Mph > 5 && x.Mph < 100).ToList();
                    totalDistance = RelevantTrips.Select(x => x.Distance).DefaultIfEmpty(0).Sum();
                    avgMph = RelevantTrips.Select(x => x.Mph).DefaultIfEmpty(0).Average();
                }

                record = $"{driver.Name}: {Math.Round(totalDistance)} miles";

                if (totalDistance > 0) { record += $" @ {Math.Round(avgMph)} mph"; }

                Records.Add(record);
            }

            Report result = new Report(Records);

            return result;

        }
    }
}