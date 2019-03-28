using System;
using System.IO;
using System.Collections.Generic;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 0) { Console.WriteLine("Please specify a path to input file"); return; }

            var path = args[0];

            string[] input = File.ReadAllLines(path);

            IEnumerable<string[]> Commands = InputService.GetCommandsFromInput(input);

            List<object> objs = new List<object>();
            foreach (string[] cmd in Commands)
            {
                objs.Add(InputService.CreateObjectFromCommand(cmd));
            }

            IEnumerable<Driver> Drivers = DriverService.AssociateTripsToDrivers(objs);

            Report DriverReport = ReportService.CreateReport(Drivers);

            Console.WriteLine(DriverReport.ToString());

        }
    }
}