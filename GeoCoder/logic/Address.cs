using System;
using System.Net;
using System.Xml.XPath;

namespace GeoCoder.logic
{
    public class Address
    {
        private string _address;
        private double _xCoord;
        private double _yCoord;
        private string _orderNum;

        public string OrderNum
        {
            get { return _orderNum; }
            set { _orderNum = value; }
        }

        public string AddressString
        {
            get { return _address; }
            set { _address = value; }
        }

        public double X
        {
            get { return _xCoord; }
            set { _xCoord = value; }
        }

        public double Y
        {
            get { return _yCoord; }
            set { _yCoord = value; }
        }

        public Address()
        {
            _address = "";
            _orderNum = "";
            _xCoord = 0.0;
            _yCoord = 0.0;
        }

        public Address(string addressNew)
        {
            _address = addressNew;
            _orderNum = "";
            _xCoord = 0.0;
            _yCoord = 0.0;
        }

        public Address(string collect, string address)
        {
            this._orderNum = collect;
            this._address = address;
            _xCoord = 0.0;
            _yCoord = 0.0;
        }

        public void Geocode()
        {
            GeoCoder();
        }

        private void GeoCoder()
        {
            var newXcoords = "0.0";
            var newYcoords = "0.0";
            var url = "http://maps.googleapis.com/maps/api/geocode/" +
                "xml?address="+this._address+"&sensor=false";

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
                        return;
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
            this.Y = Convert.ToDouble(newYcoords);
            this.X = Convert.ToDouble(newXcoords);
        }
    }
}
