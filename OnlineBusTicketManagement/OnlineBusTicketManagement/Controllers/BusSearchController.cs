using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicketManagement.Controllers
{
    public class BusSearchController : Controller
    {
        // GET: BusSearch
        public ActionResult SearchBus()
        {
            return View(new SearchBus());
        }
        public ActionResult ViewSeat()
        {
            var temp = new List<int>() { 5, 10, 25 };
            ViewBag.SeatList = temp;
            return View();
        }
        public ActionResult SearchResult()
        {
            return View();
        }
    }
}