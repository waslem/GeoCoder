using GeoCoder.Encrypt;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GeoCoder.logic
{
    /// <summary>
    /// This class is used to email the results of the geocoding service to the required user.
    /// </summary>
    public class Email
    {
        private SmtpClient smtp;

        /// <summary>
        /// default constructor, simply initialise the smtp client by seting the required settings
        /// for sending email successfully on Baycorp's BCS network
        /// </summary>
        public Email()
        {
            smtp = setupClient();
        }

        /// <summary>
        /// This method sends an email of the remaining ungeocoded orders after the geocoder has been run
        /// </summary>
        /// <param name="toAddress">the email address to send the email to</param>
        /// <param name="_ungeoList">a list of remaining ungeocoded addresses</param>
        /// <returns>true if the message was sent successfully, otherwise false</returns>
        public bool SendRemainingUngeocoded(string toAddress, List<Address> _ungeoList)
        {
            bool status = false;

            // create a list of objects which are not to be included
            var rejectList = _ungeoList.Where(u => u.X > 0.0 || u.Y > 0.0);

            // exclude the reject list from the dataset
            var filteredList = _ungeoList.Except(rejectList).ToList();

            try
            {
                // create and send the message ungeocoded email
                MailMessage messageUngeocoded = CreateUngeocodedMessage(filteredList, toAddress);
                smtp.Send(messageUngeocoded);

                status = true;
            }
            catch
            {
                status = false;
            }

            return status;
        }

        /// <summary>
        /// This method sends an email to the user with the statistics of the geocoding process
        /// </summary>
        /// <param name="toAddress">the address to send the email to</param>
        /// <param name="results">the object that is used to store the geocoder results</param>
        /// <returns>true if the message was successfully sent, otherwise false</returns>
        public bool SendResultStatistics(string toAddress, ResultStats results)
        {
            bool status = false;

            try
            {
                // create and send the message results email
                MailMessage messageResults = CreateResultsMessage(results, toAddress);
                smtp.Send(messageResults);

                status = true;
            }
            catch
            {
                status = false;
            }

            return status;
        }

        /// <summary>
        /// This method creates the results email message which is sent to the user.
        /// The results email displays
        ///     -   the total records attempted to be geocoded
        ///     -   the total records successfully geocoded
        ///     -   the total records unsuccessfully geocoded
        /// </summary>
        /// <param name="results">the results object which is used to track geocoding statistics</param>
        /// <param name="toAddress">the address to send the results email message to</param>
        /// <returns>the MailMessage that is created</returns>
        private static MailMessage CreateResultsMessage(ResultStats results, string toAddress)
        {
            // create the new mailmessage
            MailMessage message = new MailMessage();

            // enable html as we are creating a table in the body string
            message.IsBodyHtml = true;

            // set the to and from addresses, from is defined in the settings of the program
            message.To.Add(new MailAddress(toAddress));
            message.From = new MailAddress(Properties.Settings.Default.EmailUsername);

            message.Subject = "Geocoding Results - " + DateTime.Today.ToShortDateString();

            // create the message body
            message.Body = CreateResultsMessageBodyString(results);

            return message;
        }

        /// <summary>
        /// This method creates the body of the results email
        /// </summary>
        /// <param name="results">the results stats used to populate the email</param>
        /// <returns>a string of the html body</returns>
        private static string CreateResultsMessageBodyString(ResultStats results)
        {
            // we use string builder for performance as we are altering strings many times.
            // this is not required but likely best practice
            StringBuilder sb = new StringBuilder();

            // calculate the success rate of the geocoder (geocoded records / total records) * 100
            double successRate = (results.GeocodedCount / results.RecordCount) * 100;

            // set the success rate color dynamically dependent on the rate of success of the geocoder.
            string successColor = SetSuccessRateColor(successRate);

            // create the html table for displaying the results to the user
            sb.Append("<table border='1' style='text-align:center'>");
                sb.Append("<tr>");
                    sb.Append("<td><b>Total records</b></td>");
                    sb.Append("<td><b>Records Geocoded</b></td>");
                    sb.Append("<td><b>Records Ungeocoded</b></td>");
                    sb.Append("<td bgcolor='");

                    sb.Append(successColor);

                    sb.Append("<b>Success</b></td>");
                sb.Append("</tr>");
                
                // display the actual results from the results object
                sb.Append("<tr>");
                    sb.Append("<td>" + results.RecordCount + "</td>");
                    sb.Append("<td>" + results.GeocodedCount + "</td>");
                    sb.Append("<td>" + results.UngeocodedCount + "</td>");
                    sb.Append("<td bgcolor='");

                    sb.Append(successColor);

                    sb.Append(successRate.ToString("F0") + "%</td>");
                sb.Append("</tr>");
            sb.Append("</table>");

            sb.Append("<table style='padding-top:20px'>");
                sb.Append("<tbody>");
                    sb.Append("<tr>");
                        sb.Append("<td> <b>Bailiff geocoded count:</b> " + results.BailiffGeocodedCount + "</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                        sb.Append("<td> <b>In-House geocoded count:</b> " + results.ExpressGeocdedCount + "</td>");
                    sb.Append("</tr>");
                sb.Append("</tbody>");
            sb.Append("</table>");
            return sb.ToString();
        }

        /// <summary>
        /// This method sets the success rate color of the success email based on the success rate
        /// </summary>
        /// <param name="successRate">rate of success out of 100</param>
        /// <returns>the html color code</returns>
        private static string SetSuccessRateColor(double successRate)
        {
            string successColor = "";

            // set the color of the success rate statistic dependent on the success rate
            if (successRate < 10)
                successColor = "#FF0000'>";
            else if (successRate < 25)
                successColor = "#FF6600'>";
            else if (successRate < 50)
                successColor = "#FFFF66'>";
            else if (successRate < 75)
                successColor = "#99FF66'>";
            else if (successRate < 90)
                successColor = "#00FF00'>";
            else if (successRate == 100)
                successColor = "#006600'>";
            else
                successColor = "#000'>";

            return successColor;
        }

        /// <summary>
        /// This method creates the ungeocoded message, this ungeocoded message contains the 
        /// records which remain ungeocoded after being attempted to be geocoded by the geocoder
        /// </summary>
        /// <param name="_ungeoList">the list of addresses that remain ungeocoded</param>
        /// <param name="toAddress">the email address to send the message to</param>
        /// <returns>the created mail message</returns>
        private static MailMessage CreateUngeocodedMessage(List<Address> _ungeoList, string toAddress)
        {
            MailMessage message = new MailMessage();

            message.IsBodyHtml = true;
            message.To.Add(new MailAddress(toAddress));
            message.From = new MailAddress(Properties.Settings.Default.EmailUsername);

            message.Subject = "Ungeocoded - " + DateTime.Today.ToShortDateString();

            message.Body = CreateUngeoMessageBodyString(_ungeoList);

            return message;
        }

        /// <summary>
        /// This method creates the ungeocoded message html body string
        /// </summary>
        /// <param name="_ungeoList">the list of ungeocoded records</param>
        /// <returns>a string containing the html code required to create the html email message</returns>
        private static string CreateUngeoMessageBodyString(List<Address> _ungeoList)
        {
            // using stringbuilder, create the table and the rows/columns for the emailMessage body 
            StringBuilder sb = new StringBuilder();
            int recordCount = 0;

            // create the table and set the header rows
            sb.Append("<table border = 1>");
                sb.Append("<tr>");
                    sb.Append("<td><b>Count</b></td>");
                    sb.Append("<td><b>Record</b></td>");
                    sb.Append("<td><b>Address</b></td>");
                sb.Append("</tr>");

            // loop through each record in the remaining ungeocoded list and append these to the table
            foreach (var record in _ungeoList)
            {
                recordCount++;
                sb.Append("<tr>");
                    sb.Append("<td>" + recordCount + "</td>");
                    sb.Append("<td>" + record.OrderNum + "</td>");
                    sb.Append("<td>" + record.AddressString + "</td>");
                sb.Append("</tr>");
            }

            sb.Append("</table>");

            //insert into the start of the message, a summary displaying the count of ungeocoded records.
            if (_ungeoList.Count > 1)
            {
                sb.Insert(0, "<p><b> There are " + _ungeoList.Count + " ungeocoded records today </b></p>");
            }
            else
            {
                sb.Insert(0, "<p><b> There is only " + _ungeoList.Count + "ungeocoded record today </b></p>");
            }

            return sb.ToString();
        }

        /// <summary>
        /// the method which sets up the SmtpClient object, the settings which are configured are:
        ///     -   Port: the port used to communicate with the smtp server
        ///     -   Host: the hostname of the smtp server (we assume dns works, if this is down we have bigger problems)
        ///     -   Credentials: the bcs credentials of an account to send email the the Baycorp smtp server
        ///                      These credentials are encrypted using the Crypto class
        ///     - Delivery Method: Network - we send the message via the network to the smtp server,
        ///     assumes connectivity to the smtp server from the client machine
        /// </summary>
        /// <returns>the configured SmtpClient</returns>
        private static SmtpClient setupClient()
        {
            // create a new SmtpClient
            SmtpClient client = new SmtpClient();

            // set the port and host as configured in the settings of the software
            client.Port = Properties.Settings.Default.SmtpPort;
            client.Host = Properties.Settings.Default.SmtpHost;

            client.UseDefaultCredentials = false;

            // decrypt the password from the settings (we use Microsofts implementation of the TripleDES encryption protocol)
            // see the System.Security.Crpyotgraphy.TripleDES class
            Crypto crypt = new Crypto(Crypto.CryptoTypes.encTypeTripleDES);
            string pass = crypt.Decrypt(Properties.Settings.Default.EmailPassword);

            client.Credentials = new NetworkCredential(Properties.Settings.Default.EmailUsername, pass);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            return client;
        }
    }
}
