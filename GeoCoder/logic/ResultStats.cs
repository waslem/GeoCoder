using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoCoder.logic
{
    /// <summary>
    /// the class object used to store the results of the geocoding service
    /// </summary>
    public class ResultStats
    {
        /// <summary>
        /// the count of records that are imported
        /// </summary>
        public int RecordCount { get; set; }
        /// <summary>
        /// the count of geocoded records
        /// </summary>
        public int GeocodedCount { get; set; }
        /// <summary>
        /// the count of ungeocoded records
        /// </summary>
        public int UngeocodedCount { get; set; }
        /// <summary>
        /// the count of 'bailiff' geocoded records
        /// </summary>
        public int BailiffGeocodedCount { get; set; }
        /// <summary>
        /// the count of 'express' geocoded records
        /// </summary>
        public int ExpressGeocdedCount { get; set; }

        /// <summary>
        /// this reset method resets the values of all the stats to 0
        /// </summary>
        public void Reset()
        {
            this.RecordCount = 0;
            this.GeocodedCount = 0;
            this.UngeocodedCount = 0;
            this.BailiffGeocodedCount = 0;
            this.ExpressGeocdedCount = 0;
        }
    }
}
