using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace OBTM.Service
{
   public class TicketService : GenericService<Ticket>
    {
        public int RandomNumber()
        {
            Random random = new Random();
            return random.Next(1000, 9000);
        }
        public Response<int>DeleteSoft(int id)
        {
            var repository = GetInstance<ITicketRepository>();
            var result = SafeExecute(() => repository.DeleteSoft(id));
            return result;
        }
        //public Response<int> SaveEditedBus(BusOperator bus)
        //{
        //    var repository = GetInstance<IBusOpertaorRepository>();
        //    var result = SafeExecute(() => repository.SaveEditedBus(bus));
        //    return result;
        //}

        public void SendEmail( Ticket ticket)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", 25);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("Debashish110215", "deba110215");
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("onlinebusticket@gmail.com");
            mail.To.Add(new MailAddress(ticket.Email));
            mail.Subject = "Confirmation for Ticket Purchase";
            mail.Body = "<p>Dear "+ticket.Name+",<br/><br/>"+ "Congratulation." + "Your ticket is confirmed.Your ticket PIN is:"+ticket.TicketPIN+ ".Use this PIN to cancel your ticket. Your can cancel ticket anytime before 1 hour from departure time.<br/><h4>Best Regards,</h4><br/><h4>OnlineBusTicket.com</h4></p>";
            mail.IsBodyHtml = true;
            mail.BodyEncoding = UTF8Encoding.UTF8;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            smtpClient.Send(mail);

        }
        
    }
}
