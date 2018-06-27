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
            ViewBag.booking = bookingTickets;
            Ticket ticket = new Ticket()
            {
                Seats = seatList,
                TotalFare = totalFare,
                TicketPIN = ticketService.RandomNumber().ToString(),
                //Bookings = bookingTickets,
                
            };
            TempData["DateWise"] = dateWiseTripId;
            return View(ticket);
        }
        

        public ActionResult TicketDetails_(Ticket ticket)
        {
            var id = ticket.Id;
            //var bookingTickets = ticket.Bookings;
            var bookingTickets = bookingTicketService.GetAll().Where(m => m.DateWiseTripId ==(int) TempData["DateWise"] && ticket.Seats.Contains(m.SeatName)).ToList();



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
           
            
            ticketService.Save(T);
            foreach (var item in bookingTickets)
            {
                item.IsTempLocked = false;
                item.IsBooked = true;
                item.TicketId = T.Id;
                item.TicketPIN = ticket.TicketPIN;
                bookingTicketService.Update(item);
            }
            ticketService.SendEmail(ticket);
            return View(T);
        }

        public ActionResult CancelTicketView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CancelTicketConfirm(Ticket ticket)
        {
            var cancel = new TicketService().GetAll().Where(i => i.TicketPIN == ticket.TicketPIN).FirstOrDefault();
                //from objT in dbContext.Tickets where objT.TicketPIN == ticket.TicketPIN select objT;
            //Ticket T = cancel.First();
            return View(cancel);
        }
        [HttpPost]
        public ActionResult CancelTicketDone(int id)
        {
           
            ticketService.DeleteSoft(id);
            var ticket = ticketService.GetById(id);
            var bookingTickets = bookingTicketService.GetAll().Where(m => m.TicketPIN ==ticket.TicketPIN && ticket.Seats.Contains(m.SeatName)).ToList();
            foreach (var item in bookingTickets)
            {
                item.IsBooked = false;
                item.TicketPIN = null;
                bookingTicketService.Update(item);
            }
            return RedirectToAction("SearchBus","busSearch");
        }
    }
}