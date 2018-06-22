using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Core.Interfaces
{
    public interface IBookingTicketRepository: IGenericRepository<BookingTicket>
    {
        void CreateBookingTickets(int numOfSeats, int dateWiseTripId);
        int GetAvailableSeatByDateWise(int id);
    }
}
