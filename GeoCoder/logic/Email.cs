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
            message.From = new MailAddress("Schedulerbbpo@gmail.com");

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

            sb.Append("<table border = 1>");
                sb.Append("<tr>");
                    sb.Append("<td><b>Total records</b></td>");
                    sb.Append("<td><b>Records Geocoded</b></td>");
                    sb.Append("<td><b>Records Ungeocoded</b></td>");
                    sb.Append("<td><b>Success</b></td>");
                sb.Append("</tr>");

                sb.Append("<tr>");
                    sb.Append("<td>" + results.RecordCount + "</td>");
                    sb.Append("<td>" + results.GeocodedCount + "</td>");
                    sb.Append("<td>" + results.UngeocodedCount + "</td>");
                    sb.Append("<td>" + successRate.ToString("F0") + "%</td>");
                sb.Append("</tr>");
            sb.Append("</table>");

            return sb.ToString();
        }

        private static MailMessage CreateUngeocodedMessage(List<Address> _ungeoList, string toAddress)
        {
            MailMessage message = new MailMessage();

            message.IsBodyHtml = true;
            message.To.Add(new MailAddress(toAddress));
            message.From = new MailAddress("schedulerbbpo@gmail.com");

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

            client.Port = Properties.Settings.Default.EmailPort;
            client.Host = Properties.Settings.Default.EmailHost;

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;

            client.Credentials = new NetworkCredential
                (Properties.Settings.Default.EmailUsername, Properties.Settings.Default.EmailPassword);

            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            return client;
        }
    }
}
