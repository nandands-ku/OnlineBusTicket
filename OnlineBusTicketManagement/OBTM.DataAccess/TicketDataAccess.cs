using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.DataAccess
{
   public class TicketDataAccess : GenericDataAccess<Ticket>, ITicketRepository
    {

        public TicketDataAccess(OBTMDbContext context) : base(context)
        {
            
        }
        public int DeleteSoft(object id)
        {
            var obj = OBTMDbSet.Find(id);
            obj.IsDeleted = true;
            OBTMDbContext.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            
            return OBTMDbContext.SaveChanges();
        }

        
        public int SendEmail(Ticket ticket)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("onlinebusticketdatagrid@gmail.com", "onlinebus545655");
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("onlinebusticketdatagrid@gmail.com", "Onlinebusticket.com");

            mail.To.Add(new MailAddress(ticket.Email));
            mail.Subject = "Confirmation for Ticket Purchase";
            mail.Body = "<p>Dear " + ticket.Name + ",<br/><br/>" + "Congratulation." + "Your ticket is confirmed.Your ticket PIN is:" + ticket.TicketPIN + ".Use this PIN to cancel your ticket. Your can cancel ticket anytime before 1 hour from departure time.<br/><h4>Best Regards,</h4><br/><h4>OnlineBusTicket.com</h4></p>";
            //mail.Body = "Hello";
            mail.IsBodyHtml = true;
            mail.BodyEncoding = UTF8Encoding.UTF8;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            smtpClient.ServicePoint.MaxIdleTime = 1;
            try
            {
                smtpClient.Send(mail);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
