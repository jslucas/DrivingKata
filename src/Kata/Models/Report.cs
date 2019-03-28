using System;
using System.Collections.Generic;

namespace Kata
{
    public class Report
    {

        public IEnumerable<string> Records { get; private set; }

        public Report(IEnumerable<string> Records)
        {
            this.Records = Records;
        }

        public override string ToString()
        {
            return String.Join(Environment.NewLine, Records);
        }

    }
}