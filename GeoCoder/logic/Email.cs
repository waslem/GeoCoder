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
    public static class Email
    {
        public static bool Send(string toAddress, List<Address> _ungeoList)
        {
            // track success status of method
            bool status = false;

            try
            {
                // create a new smtp client with required settings
                SmtpClient smtp = setupClient();

                // create the mailMessage from the ungeo list
                MailMessage messageUngeocoded = CreateUngeocodedMessage(_ungeoList, toAddress);

                if (_ungeoList.Count > 0)
                {
                    // send the message if there are ungeocoded records to send
                    smtp.Send(messageUngeocoded);
                    status = true;
                }
            }
            catch(SmtpException ex)
            {
                Debug.Write(ex.Message); 
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

            return status;
        }

        private static MailMessage CreateUngeocodedMessage(List<Address> _ungeoList, string toAddress)
        {
            MailMessage message = new MailMessage();

            message.IsBodyHtml = true;
            message.From = new MailAddress("schedulerbbpo@gmail.com");
            message.To.Add(new MailAddress(toAddress));

            message.Subject = "TESTING PLEASE IGNORE - ";
            message.Subject += "Ungeocoded - " + DateTime.Today.ToShortDateString();

            message.Body = CreateMessageBodyString(_ungeoList);

            return message;
        }

        private static string CreateMessageBodyString(List<Address> _ungeoList)
        {
            // using string builder, create the table and the rows/columns for the emailMessage body 
            StringBuilder sb = new StringBuilder();
            int recordCount = 0;

            if (_ungeoList.Count > 0)
            {
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
            }

            return sb.ToString();
        }

        private static SmtpClient setupClient()
        {
            SmtpClient client = new SmtpClient();

            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;

            client.Credentials = new NetworkCredential("schedulerbbpo@gmail.com", "Schedule24");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            return client;
        }
    }
}
