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
    public class Email
    {
        private SmtpClient smtp;

        public Email()
        {
            smtp = setupClient();
        }

        public bool Send(string toAddress, List<Address> _ungeoList)
        {
            bool status = false;

            var rejectList = _ungeoList.Where(u => u.X > 0.0 || u.Y > 0.0);

            var filteredList = _ungeoList.Except(rejectList).ToList();

            try
            {
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

        public bool Send(string toAddress, ResultStats results)
        {
            bool status = false;

            try
            {
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

        private static MailMessage CreateResultsMessage(ResultStats results, string toAddress)
        {
            MailMessage message = new MailMessage();

            message.IsBodyHtml = true;
            message.To.Add(new MailAddress(toAddress));
            message.From = new MailAddress(Properties.Settings.Default.EmailUsername);

            message.Subject = "Geocoding Results - " + DateTime.Today.ToShortDateString();

            message.Body = CreateResultsMessageBodyString(results);

            return message;
        }

        private static string CreateResultsMessageBodyString(ResultStats results)
        {
            StringBuilder sb = new StringBuilder();

            double geoCount = results.GeocodedCount;
            double totalCount = results.RecordCount;
            double successRate = (geoCount / totalCount) * 100;
            string successColor = "";

            // style it up!
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

            sb.Append("<table border='1' style='text-align:center'>");
                sb.Append("<tr>");
                    sb.Append("<td><b>Total records</b></td>");
                    sb.Append("<td><b>Records Geocoded</b></td>");
                    sb.Append("<td><b>Records Ungeocoded</b></td>");
                    sb.Append("<td bgcolor='");

                    sb.Append(successColor);

                    sb.Append("<b>Success</b></td>");
                sb.Append("</tr>");

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

        private static MailMessage CreateUngeocodedMessage(List<Address> _ungeoList, string toAddress)
        {
            MailMessage message = new MailMessage();

            message.IsBodyHtml = true;
            message.To.Add(new MailAddress(toAddress));
            message.From = new MailAddress(Properties.Settings.Default.EmailUsername);

            message.Subject = "Ungeocoded - " + DateTime.Today.ToShortDateString();

            message.Body = CreateMessageBodyString(_ungeoList);

            return message;
        }

        private static string CreateMessageBodyString(List<Address> _ungeoList)
        {
            // using stringbuilder, create the table and the rows/columns for the emailMessage body 
            StringBuilder sb = new StringBuilder();
            int recordCount = 0;

            sb.Append("<table border = 1>");
                sb.Append("<tr>");
                    sb.Append("<td><b>Count</b></td>");
                    sb.Append("<td><b>Record</b></td>");
                    sb.Append("<td><b>Address</b></td>");
                sb.Append("</tr>");

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

        private static SmtpClient setupClient()
        {
            SmtpClient client = new SmtpClient();

            client.Port = Properties.Settings.Default.SmtpPort;
            client.Host = Properties.Settings.Default.SmtpHost;

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;

            Crypto crypt = new Crypto(Crypto.CryptoTypes.encTypeTripleDES);
            string pass = crypt.Decrypt(Properties.Settings.Default.EmailPassword);

            client.Credentials = new NetworkCredential(Properties.Settings.Default.EmailUsername, pass);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            return client;
        }
    }
}
