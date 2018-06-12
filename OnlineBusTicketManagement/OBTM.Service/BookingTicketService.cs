using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Service
{
    public class BookingTicketService : GenericService<BookingTicket>
    {
        SeatBaseService seatBaseService = new SeatBaseService();
        public void CreateBookingTickets(int numOfTickets, int dateWiseTripId)
        {
            for (int i = 1; i <= numOfTickets; i++)
            {
                BookingTicket bookingTicket = new BookingTicket
                {
                    DateWiseTripId = dateWiseTripId,
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    IsBooked = false,
                    IsTempLocked = false,
                    IsDeleted = false,
                    SeatName = seatBaseService.GetSeatName(i),
                };
                Save(bookingTicket);
            }
        }
    }
}
