using OBTM.Core.Models;
using OBTM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicketManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var busService = new BusOperatorService();
            //var all = busService.GetAllBusOperators();
            //var single = busService.GetById(1);
            BusOperator bo = new BusOperator()
            {
                Name="Green Line",
                Email = "greenLine@gmail.com"
                
            };
            busService.Save(bo);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
    }
}