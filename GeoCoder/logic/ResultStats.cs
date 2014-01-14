﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoCoder.logic
{
    public class ResultStats
    {
        public int RecordCount { get; set; }
        public int GeocodedCount { get; set; }
        public int UngeocodedCount { get; set; }

        public void Reset()
        {
            this.RecordCount = 0;
            this.GeocodedCount = 0;
            this.UngeocodedCount = 0;
        }
    }
}
