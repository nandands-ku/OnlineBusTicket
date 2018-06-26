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

        public int GetAvailableSeatByDateWise(int id)
        {
            var repository = GetInstance<IBookingTicketRepository>();
            var result = SafeExecute(() => repository.GetAvailableSeatByDateWise(id));
            return result.Data;
        }

        public void ExtendBookingTickets(int ticketSeed, int numOfExtendedSeats, int dateWiseTripId)
        {
            IEnumerable<BookingTicket> deletedBookingTickets = GetAll().Where(bt => bt.DateWiseTripId == dateWiseTripId && bt.IsDeleted == true);
            int count = 0;
            int newSeatSeed = ticketSeed;

            if (deletedBookingTickets!= null)
            {
                foreach (var bookingTicket in deletedBookingTickets)
                {
                    bookingTicket.IsDeleted = false;
                    Update(bookingTicket);
                    ++count;
                    if (count == numOfExtendedSeats)
                    {
                        break;
                    }
                }
                if (count<numOfExtendedSeats)
                {
                    newSeatSeed = ticketSeed+count;
                    ticketSeed++;
                }
                else
                {
                    newSeatSeed = Int32.MaxValue;
                }
            }

            for (int i = newSeatSeed; i < ticketSeed + numOfExtendedSeats; i++)
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

        public void ReduceBookingTickets(int numOfReducedSeats, int dateWiseTripId)
        {
            IEnumerable<BookingTicket> bookingTicketList = GetAll().Where(bt => bt.DateWiseTripId == dateWiseTripId && bt.IsBooked!= true && bt.IsDeleted != true);

            int count = 0;
            foreach (var bookingTicket in bookingTicketList)
            {
                bookingTicket.IsDeleted = true;
                Update(bookingTicket);
                ++count;
                if (count == numOfReducedSeats)
                    break;
            }
        }

    }
}
