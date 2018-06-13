using OBTM.Core.Models;
using OBTM.DataAccess;
using OBTM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicketManagement.Controllers
{
    public class BusSearchController : Controller
    {
        RoutePointsService rps = new RoutePointsService();
        TripBaseService tbs = new TripBaseService();
        DateWiseTripService dws = new DateWiseTripService();
        OBTMDbContext context = new OBTMDbContext();
        public List<TripBase> tripBases = new List<TripBase>();
        public List<DateWiseTrip> dateWiseTrips = new List<DateWiseTrip>();
        // GET: BusSearch
        public List<BusOperator> busOperators = new List<BusOperator>();

        OBTMDbContext dbContext = new OBTMDbContext();

        BusOperatorService operatorService = new BusOperatorService();
        TripBaseService tripBaseService = new TripBaseService();
        BookingTicketService bookingTicketService = new BookingTicketService();
        DateWiseTripService dateWiseTripService = new DateWiseTripService();

        public ActionResult SearchBus()
        {
            ViewBag.BusOperatorList = new SelectList(context.BusOperators, "Id", "Name");
            ViewBag.LocationList = new SelectList(context.Locations, "Id", "Location");
            return View(new SearchBus());
        }

        //int dateWiseTripId
        public ActionResult ViewSeat()
        {
            var temp = new List<int>() { 5, 10, 25 };
            //ViewBag.TotalFare = dateWiseTripService.GetById(dateWiseTripId).Fare;
            //ViewBag.SeatList = bookingTicketService.GetAll().Where(m => m.IsBooked != true&&m.IsTempLocked!=true).ToList();
            ViewBag.SeatList = temp;
            return View();
        }
        [HttpPost]
        public ActionResult SearchResult(SearchBus searchBus)
        {
            ViewBag.BusOperatorList = context.BusOperators.ToList();
            //ViewBag.LocationList = context.Locations.ToList();
            var routeList = rps.GetRoute(searchBus.From, searchBus.To);
            
            foreach (var item in routeList)
            {
                if (tbs.GetTripByRouteId(item)!=null)
                {
                    tripBases.AddRange(tbs.GetTripByRouteId(item));
        }
                //try
                //{
                //    tripBases.AddRange(tbs.GetTripByRouteId(item));
                //}
                //catch (Exception)
                //{

                //    Response.Write("Tripbase for the corresponding route is missing in Tripbase table");
                //}
                
    }
            foreach (var item in tripBases)
            {
                if (dws.GetDateWiseByTrip(item.Id) != null)
                {
                    dateWiseTrips.AddRange(dws.GetDateWiseByTrip(item.Id));
                }
                    
            }
            SearchBus s = new SearchBus
            {
                GetDateWiseTrip = dateWiseTrips
            };

            return View(s);
        }
        //public ActionResult SearchResult()
        //{
        //    return View();
        //}
    }
}