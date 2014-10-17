using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoCoder.logic
{
    /// <summary>
    /// This class used to export orders to the required file format
    /// </summary>
    public class AddressExport
    {
        public string OrderNum { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string DriverName { get; set; }
    }
}
