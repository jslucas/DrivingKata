using System;
using System.Collections.Generic;
using Xunit;

namespace Kata.Tests
{
    public class DriverServiceTests
    {
        [Theory]
        [MemberData(nameof(AssignTripsToDriversTestCase))]
        public void AssociateTripsToDrivers(IEnumerable<object> objs, IEnumerable<Driver> expected)
        {

            IEnumerable<Driver> actual = DriverService.AssociateTripsToDrivers(objs);

            Assert.NotStrictEqual(expected, actual);
        }

        #region "Test Cases"

        public static List<object[]> AssignTripsToDriversTestCase =>
            new List<object[]>
            {
               new object[]
               {
                    new List<object>
                    {
                        new Driver { Name = "Rom" },
                        new Trip("Rom", "07:15", "7:45", "17.3"),
                        new Trip("Rom", "01:15", "17:38", "73.3"),
                        new Driver { Name = "Quark"},
                        new Trip("Quark", "02:14", "06:33", "26.8"),
                        new Trip("Quark", "12:14", "1:15", "226"),
                        new Driver { Name = "LargeMarge"}
                    },
                    new List<Driver>
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
                    }
               }
            };

        #endregion
    }
}