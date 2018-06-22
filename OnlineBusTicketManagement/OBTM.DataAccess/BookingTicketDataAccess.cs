using OBTM.Core.Models;
using OBTM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.DataAccess
{
    public class BookingTicketDataAccess : GenericDataAccess<BookingTicket>, IBookingTicketRepository
    {
        public BookingTicketDataAccess(OBTMDbContext context) : base(context)
        {
        }

        public void CreateBookingTickets(int numOfSeats, int dateWiseTripId)
        {
            throw new NotImplementedException();
        }


        public int GetAvailableSeatByDateWise(int id)
        {
            var count = OBTMDbContext.BookingTickets.Where(c => c.DateWiseTripId == id && c.IsBooked!=true).Count();
            return count;
        }

    }
}
