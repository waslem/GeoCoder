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
            _address = " ";
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
    }
}
