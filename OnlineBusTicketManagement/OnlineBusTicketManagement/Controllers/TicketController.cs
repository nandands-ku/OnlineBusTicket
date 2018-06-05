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
    }
}