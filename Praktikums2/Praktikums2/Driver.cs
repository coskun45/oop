using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikums2
{
    class Driver
    {
       readonly string  driverName;
        public string DriverName { get; set; }
        public Driver(string driverName)
        {
            this.driverName = driverName;
        }
    }
}
