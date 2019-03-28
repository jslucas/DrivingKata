using System;

namespace Kata
{
    public class Trip
    {
        public string DriverName { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        public double Distance { get; private set; }
        public double Mph { get; private set; }

        public Trip(string driverName, string startTime, string endTime, string distance)
        {
            this.DriverName = driverName;
            this.StartTime = TimeSpan.Parse(startTime);
            this.EndTime = TimeSpan.Parse(endTime);
            this.Distance = Convert.ToDouble(distance);
            this.Mph = this.Distance / (this.EndTime.Subtract(this.StartTime).TotalMinutes / 60);
        }

    }
}