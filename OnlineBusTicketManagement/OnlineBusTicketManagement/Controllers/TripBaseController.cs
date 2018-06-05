using OBTM.Core.Models;
using OBTM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicketManagement.Controllers
{
    public class TripBaseController : Controller
    {
        // GET: TripBase
        public ActionResult Index()
        {
            TripBaseService tbs = new TripBaseService();
            TripBase tb = new TripBase() {
                BusType = "AC",
                DepartureTime = TimeSpan.Parse("10:11"),
                RouteId = 1,
                BusOperatorId=2,
                 
                
            };
            tbs.Save(tb);
            return View();
        }
    }
}