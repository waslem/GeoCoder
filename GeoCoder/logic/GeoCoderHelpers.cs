using ComLib.CsvParse;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using GeoCoder.Properties;
using GeoCoder.Encrypt;

namespace GeoCoder.logic
{
    public static class GeoCoderHelpers
    {
        public static List<Address> LoadCsv(string fileName, List<Address> _ungeoList)
        {
            CsvDoc csv = Csv.Load(fileName, true);

            // hack way to do this now, will think of better way later.
            // TODO: fix the loading the csv to be more robust, need to error check this
            foreach (OrderedDictionary t in csv.Data)
            {
                // fix if the address is blank or just a space
                if (t[1].ToString() == " " || t[1].ToString() == "" || t[1].ToString() == null)
                {
                    _ungeoList.Add(new Address(t[0] as string, " "));
                }
                else                                            
                {
                    _ungeoList.Add(new Address(t[0] as string, t[1] as string));
                }
            }

            return _ungeoList;
        }

        public static List<Address> SortResults(List<Address> _ungeoList)
        {
            List<Address> listFixed = new List<Address>();

            // fix to remove null values from the ungeoList to stop exception by sorting null values below.
            foreach (var address in _ungeoList)
            {
                if (address != null)
                {
                    listFixed.Add(address);
                }
            }
            //sort list by y then x then ordernumber
            listFixed = listFixed.OrderBy(address => address.Y)
                                .ThenBy(address => address.X)
                                .ThenBy(address => address.OrderNum)
                                .ToList();

            return listFixed;
        }

        public static ResultStats CalculateResults(List<Address> _ungeoList)
        {
            ResultStats stats = new ResultStats();

            stats.RecordCount = _ungeoList.Count;

            int geoCount = 0;
            int bailiffGeoCount = 0;
            int expressGeoCount = 0;
            int temp;

            // loop through each address
            //      if address is geocoded (address.x > 0)
            //      find if address is a bailiff or express, using the cutoff setting
            //      if so increment the required statistic
            foreach (var address in _ungeoList)
            {
                if (address.X > 0)
                {
                    geoCount++;

                    if (Int32.TryParse(address.OrderNum, out temp))
                    {
                        if (temp >= Properties.Settings.Default.ReferenceCutoff)
                        {
                            bailiffGeoCount++;
                        }
                        else
                        {
                            expressGeoCount++;
                        }
                    }
                }
            }

            stats.GeocodedCount = geoCount;
            stats.UngeocodedCount = stats.RecordCount - geoCount;
            stats.BailiffGeocodedCount = bailiffGeoCount;
            stats.ExpressGeocdedCount = expressGeoCount;

            return stats;
        }

        public static Address GeoCode(Address record)
        {
            var newXcoords = "0.0";
            var newYcoords = "0.0";
            var url = Properties.Settings.Default.GoogleMapApiLink + record.AddressString + "&sensor=false";

            WebResponse response = null;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                // baycorp proxy settings; todo: move these to settings
                var baycorpProxy = new WebProxy();
                baycorpProxy.BypassProxyOnLocal = true;
                baycorpProxy.Address = new Uri(Properties.Settings.Default.ProxyAddress);

                Crypto crypt = new Crypto(Crypto.CryptoTypes.encTypeTripleDES);
                string pass = crypt.Decrypt(Properties.Settings.Default.proxyPassword);

                // use the crpyto class and encrypt the password, store both in settings.settings
                baycorpProxy.Credentials = new NetworkCredential
                    (Properties.Settings.Default.proxyUsername, pass);

                request.Proxy = baycorpProxy;

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

        public static List<AddressExport> ConvertList(List<Address> _ungeoList, int startRef, int finishRef)
        {
            List<AddressExport> list = new List<AddressExport>();

            foreach (var record in _ungeoList)
            {
                if (record.X != 0.0 && record.Y != 0.0)
                {
                    if (Int32.Parse(record.OrderNum) > startRef && Int32.Parse(record.OrderNum) < finishRef)
                    {
                        list.Add(new AddressExport
                        {
                            OrderNum = record.OrderNum,
                            DriverName = "",
                            X = record.X,
                            Y = record.Y
                        });
                    }
                }
            }

            return list;
        }
    }
}
