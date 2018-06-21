using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OBTM.DataAccess;
using OBTM.Service;

namespace OnlineBusTicketManagement.Controllers
{
    public class TicketController : Controller
    {
        BookingTicketService bookingTicketService = new BookingTicketService();
        TicketService ticketService = new TicketService();
        OBTMDbContext dbContext = new OBTMDbContext();

        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult ShowTicketInfo(String seatList, int totalFare,int dateWiseTripId)
        {
            var seatNameList = seatList.Split(',').ToList();
            var bookingTickets = bookingTicketService.GetAll().Where(m => m.DateWiseTripId == dateWiseTripId && seatNameList.Contains(m.SeatName)).ToList();
            //string[] arr1 = new string[] { "A", "B", "C" };
            foreach (var item in bookingTickets)
            {
                item.IsTempLocked = true;
                bookingTicketService.Update(item);
            }

            Ticket ticket = new Ticket()
            {
                Seats = seatList,
                TotalFare = totalFare,
                TicketPIN = ticketService.RandomNumber().ToString(),
                Bookings = bookingTickets
            };

            return View(ticket);
        }
        

        public ActionResult TicketDetails_(Ticket ticket)
        {
            var id = ticket.Id;
            var bookingTicket = ticket.Bookings;

            Ticket T = new Ticket()
            {
                Name=ticket.Name,
                CellNo = ticket.CellNo,
                Email = ticket.Email,
                Seats=ticket.Seats,
                TotalFare = ticket.TotalFare,
                TicketPIN = ticket.TicketPIN,
                CreditCard = ticket.CreditCard
            };
            foreach (var item in bookingTicket)
            {
                item.IsTempLocked = false;
                item.IsBooked = true;
                bookingTicketService.Update(item);
            }
            
            ticketService.Save(T);

            
            return View(T);
        }

        public ActionResult CancelTicketView()
        {
            return View();
        }

        public ActionResult CancelTicketConfirm(Ticket ticket)
        {
            var cancel = from objT in dbContext.Tickets where objT.TicketPIN == ticket.TicketPIN select objT;
            Ticket T = cancel.First();
            return View(T);
        }
        public ActionResult CancelTicketDone(Ticket ticket)
        {
            var cancelDone = from obj in dbContext.Tickets where obj.Id == ticket.Id select obj;
            Ticket T = cancelDone.First();
            ticketService.DeleteSoft(T.Id);
            return RedirectToAction("SearchBus","busSearch");
        }
    }
}