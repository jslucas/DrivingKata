using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public static class DriverService
    {
        public static IEnumerable<Driver> AssociateTripsToDrivers(IEnumerable<object> objs)
        {
            IEnumerable<Driver> Drivers = objs.OfType<Driver>();

            foreach (Driver driver in Drivers)
            {
                driver.Trips = objs.OfType<Trip>().Where(x => x.DriverName.Equals(driver.Name)).ToList();
            }

            return Drivers;
        }
        
    }
}