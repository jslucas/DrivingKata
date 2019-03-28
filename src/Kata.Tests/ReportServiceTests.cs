using System;
using System.Collections.Generic;
using Xunit;

namespace Kata.Tests
{
    public class ReportServiceTests
    {
        [Fact]
        public void GenerateReportFromDrivers()
        {
            List<Driver> Drivers = GenerateReportFromDriversTestData();

            string expected =
                $"Rom: 17 miles @ 35 mph{Environment.NewLine}" +
                $"Quark: 27 miles @ 6 mph{Environment.NewLine}" +
                $"LargeMarge: 0 miles";

            string actual = ReportService.CreateReport(Drivers).ToString();

            Assert.Equal(expected, actual);
        }

        #region "Test Cases"

        private static List<Driver> GenerateReportFromDriversTestData()
        {
            return new List<Driver>
            {
               new Driver
               {
                   Name = "Rom",
                   Trips = new List<Trip>
                    {
                        new Trip("Rom", "07:15", "7:45", "17.3"),
                        new Trip("Rom", "01:15", "17:38", "73.3")
                    }
                },
                new Driver
                {
                    Name = "Quark",
                    Trips = new List<Trip>
                     {
                         new Trip("Quark", "02:14", "06:33", "26.8"),
                         new Trip("Quark", "12:14", "1:15", "226")
                     }
                },
                new Driver { Name = "LargeMarge"}
            };
        }

        #endregion

    }
}