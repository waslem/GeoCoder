using System;
using System.Net;
using System.Xml.XPath;

namespace GeoCoder.logic
{
    /// <summary>
    /// main class used to store addresses in the geocoder.
    /// the address class contains 4 main fields:
    ///     -   _address    : the address string from the database
    ///     -   _xCoord     : the x coordinate of the address
    ///     -   _yCoord     : the y coordinate of the address
    ///     -   _orderNum   : the order number, this refers to the Collect reference of the address being geocoded
    /// </summary>
    public class Address
    {
        private string _address;
        private double _xCoord;
        private double _yCoord;
        private string _orderNum;

        /// <summary>
        /// get/set the orderNum
        /// </summary>
        public string OrderNum
        {
            get { return _orderNum; }
            set { _orderNum = value; }
        }

        /// <summary>
        /// get/set the address string
        /// </summary>
        public string AddressString
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// get/set the x coordinate
        /// </summary>
        public double X
        {
            get { return _xCoord; }
            set { _xCoord = value; }
        }

        /// <summary>
        /// get/set the y coordinate
        /// </summary>
        public double Y
        {
            get { return _yCoord; }
            set { _yCoord = value; }
        }

        /// <summary>
        /// default constructor for the address object
        /// initialises the default value for all fields
        /// </summary>
        public Address()
        {
            _address = " ";
            _orderNum = "";
            _xCoord = 0.0;
            _yCoord = 0.0;
        }

        /// <summary>
        /// constructor for the address object, passes in an address string.
        /// initialises the default value of the other fields
        /// </summary>
        /// <param name="addressNew">the address string to be added to the newly created address object</param>
        public Address(string addressNew)
        {
            _address = addressNew;
            _orderNum = "";
            _xCoord = 0.0;
            _yCoord = 0.0;
        }

        /// <summary>
        /// constructor for the address object, passes in an address and Collect reference
        /// initialises the default value of the other fields
        /// </summary>
        /// <param name="collect">the collect reference of the order being created</param>
        /// <param name="address">the address of the order being created</param>
        public Address(string collect, string address)
        {
            this._orderNum = collect;
            this._address = address;
            _xCoord = 0.0;
            _yCoord = 0.0;
        }
    }
}
