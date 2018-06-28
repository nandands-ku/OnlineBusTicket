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
        public Response<int> DeleteSoft(int id)
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
        public void UpdateBooking(int id)
        {
            BookingTicketService bookingTicketService = new BookingTicketService();
            TicketService ticketService = new TicketService();
            var ticket = ticketService.GetById(id);
            var bookingTickets = bookingTicketService.GetAll().Where(m => m.TicketPIN == ticket.TicketPIN && ticket.Seats.Contains(m.SeatName)).ToList();
            foreach (var item in bookingTickets)
            {
                item.IsBooked = false;
                item.TicketPIN = null;
                bookingTicketService.Update(item);
            }

        }

        public Response<int> SendEmail(Ticket ticket)
        {
            var repository = GetInstance<ITicketRepository>();
            var result = SafeExecute(()=>repository.SendEmail(ticket));
            return result;
        }
       

    }
}
