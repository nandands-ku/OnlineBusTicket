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

        public Response<int> SendEmail(Ticket ticket)
        {
            var repository = GetInstance<ITicketRepository>();
            var result = SafeExecute(()=>repository.SendEmail(ticket));
            return result;
        }
       

    }
}
