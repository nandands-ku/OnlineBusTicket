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
    public class BusSearchController : Controller
    {
        
        // GET: BusSearch
        public List<BusOperator> busOperators = new List<BusOperator>();

        OBTMDbContext dbContext = new OBTMDbContext();

        BusOperatorService operatorService = new BusOperatorService();
        TripBaseService tripBaseService = new TripBaseService();

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
            ViewBag.OperatorList = operatorService.GetAll();
            //ViewBag.BusType = tripBaseService.GetAll();
            return View();
        }
    }
}