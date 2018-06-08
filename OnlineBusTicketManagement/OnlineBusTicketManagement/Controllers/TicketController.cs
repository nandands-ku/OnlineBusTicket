using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicketManagement.Controllers
{
    public class TicketController : Controller
    {

        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TicketInfo()
        {
            return View(new Ticket());
        }
        public ActionResult TicketDetails()
        {
            return View();
        }
        public ActionResult TicketDetails_()
        {
            return View();
        }
    }
}