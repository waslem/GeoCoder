using ComLib.CsvParse;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace GeoCoder.logic
{
    public static class GeoCoderHelpers
    {
        public static bool EmailUngeo(List<Address> _ungeoList)
        {
            bool success = false;

            // refine the list to the ungeo 
            List<Address> _ungeoListLeft = _ungeoList
                            .Where(u => u.X == 0.0)
                            .Where(u => u.Y == 0.0)
                            .ToList();

            if (Email.Send("info@backofficebpo.com.au", _ungeoListLeft))
                success = true;

            return success;
        }

        public static List<Address> LoadCsv(string fileName, List<Address> _ungeoList)
        {
            CsvDoc csv = Csv.Load(fileName, true);

            // hack way to do this now, will think of better way later.
            // TODO: fix the loading the csv to be more robust, need to error check this
            foreach (OrderedDictionary t in csv.Data)
            {
                // assumes input from csv is in correct format
                _ungeoList.Add(new Address(t[0] as string, t[1] as string));
            }

            return _ungeoList;
        }

        public static List<Address> SortResults(List<Address> _ungeoList)
        {
            //sort list by y then x then ordernumber
            _ungeoList = _ungeoList.OrderBy(address => address.Y)
                                .ThenBy(address => address.X)
                                .ThenBy(address => address.OrderNum)
                                .ToList();

            return _ungeoList;
        }

        public static ResultStats CalculateResults(List<Address> _ungeoList)
        {
            ResultStats stats = new ResultStats();

            stats.RecordCount = _ungeoList.Count;

            int i = 0;

            foreach (var address in _ungeoList)
            {
                if (address.X > 0)
                    i++;
            }

            stats.GeocodedCount = i;
            stats.UngeocodedCount = stats.RecordCount - i;

            return stats;
        }

        public static Address GeoCode(Address record)
        {
            var newXcoords = "0.0";
            var newYcoords = "0.0";
            var url = "http://maps.googleapis.com/maps/api/geocode/" +
                "xml?address=" + record.AddressString + "&sensor=false";

            WebResponse response = null;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                response = request.GetResponse();
                var exactResult = 0;

                var doc = new XPathDocument(response.GetResponseStream());
                XPathNavigator nav = doc.CreateNavigator();
                XPathNodeIterator statusIterator = nav.Select("/GeocodeResponse/status");
                while (statusIterator.MoveNext())
                {
                    if (statusIterator.Current.Value != "OK")
                    {
                        // error, this means google was unable to geo code the address
                        return null;
                    }
                }
                XPathNodeIterator resultsIterator = nav.Select("/GeocodeResponse/result");
                while (resultsIterator.MoveNext())
                {
                    XPathNodeIterator geometryIterator = resultsIterator.Current.Select("geometry");
                    while (geometryIterator.MoveNext())
                    {
                        XPathNodeIterator locationTypeIterator = geometryIterator.Current.Select("location_type");
                        while (locationTypeIterator.MoveNext())
                        {
                            // only get results for "ROOFTOP" or "RANGE_INTERPOLATED" level of accuracy, we are currently only using "ROOFTOP" accuracy
                            if (locationTypeIterator.Current.Value == "ROOFTOP")// || locationTypeIterator.Current.Value == "RANGE_INTERPOLATED")
                            {
                                exactResult = 1;
                            }
                        }
                        //if we have a result from the google api in which the location is rooftop, then retrieve the lat/long coordinates
                        if (exactResult == 1)
                        {
                            XPathNodeIterator locationIterator = geometryIterator.Current.Select("location");
                            while (locationIterator.MoveNext())
                            {
                                XPathNodeIterator latIterator = locationIterator.Current.Select("lat");
                                while (latIterator.MoveNext())
                                    newYcoords = latIterator.Current.Value;
                                XPathNodeIterator lngIterator = locationIterator.Current.Select("lng");
                                while (lngIterator.MoveNext())
                                    newXcoords = lngIterator.Current.Value;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //TODO: add exception logic here
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            record.Y = Convert.ToDouble(newYcoords);
            record.X = Convert.ToDouble(newXcoords);

            return record;
        }
    }
}
