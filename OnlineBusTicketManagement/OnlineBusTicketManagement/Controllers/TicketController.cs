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

        TicketService ticketService = new TicketService();
        OBTMDbContext dbContext = new OBTMDbContext();

        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowTicketInfo(String seatList, int totalFare)
        {
            //string[] arr1 = new string[] { "A", "B", "C" };
            Ticket ticket = new Ticket()
            {
                Seats = string.Join(",", seatList),
                TotalFare = 1000,
                TicketPIN = ticketService.RandomNumber().ToString()
            };

            return View(ticket);
        }
        

        public ActionResult TicketDetails_(Ticket ticket)
        {
            var id = ticket.Id;

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