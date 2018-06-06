using OBTM.Core.Models;
using OBTM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicketManagement.Controllers
{
    public class RouteController : Controller
    {
        // GET: Route
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveRoute(Route r)
        {
            RouteService rs = new RouteService();
            rs.Save(r);
            return View("Index");
        }
        public ActionResult DeleteRoute(int id)
        {
            RouteService rs = new RouteService();
            rs.Delete(id);
            return View("Index");
        }
    }
}