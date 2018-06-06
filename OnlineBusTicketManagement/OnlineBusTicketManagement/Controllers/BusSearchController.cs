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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewSeat()
        {
            return View();
        }
    }
}