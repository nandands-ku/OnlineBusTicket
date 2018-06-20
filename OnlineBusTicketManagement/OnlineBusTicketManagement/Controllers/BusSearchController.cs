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
        LocationsService ls = new LocationsService();
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
        SeatBaseService seatBaseService = new SeatBaseService();
        public ActionResult SearchBus()
        {
            ViewBag.BusOperatorList = new SelectList(context.BusOperators, "Id", "Name");
            ViewBag.LocationList = new SelectList(context.Locations, "Id", "Location");
            return View(new SearchBus());
        }


        public ActionResult ViewSeat(int? dateWiseTripId)
        {
            ViewBag.Fare = dateWiseTripService.GetById(dateWiseTripId).Fare;
            var BookingTickets= bookingTicketService.GetAll().Where(m =>m.DateWiseTripId== dateWiseTripId && m.IsTempLocked != true && m.IsBooked != true).Select(m=>m.SeatName).ToList();
            ViewBag.SeatNoList = seatBaseService.GetAll().Where(m => BookingTickets.Contains(m.SeatName)).Select(m => m.Id).ToList();
            ViewBag.SeatNameList = seatBaseService.GetAll().Select(m => m.SeatName).ToList();
            ViewBag.DateWiseTripId = dateWiseTripId;
            return View();
        }


        [HttpPost]
        public ActionResult SearchResult(SearchBus searchBus)
        {
            ViewBag.BusOperatorList = context.BusOperators.ToList();
            //ViewBag.LocationList = context.Locations.ToList();
            var routeList = rps.GetRoute(searchBus.From, searchBus.To);
            var from = ls.GetById(searchBus.From);
            var to = ls.GetById(searchBus.To);
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
                if (dws.GetDateWiseByTrip(item.Id, searchBus.DepartureDate) != null)
                {
                    dateWiseTrips.AddRange(dws.GetDateWiseByTrip(item.Id, searchBus.DepartureDate));
                    
                }
                    
            }

            SearchBus s = new SearchBus
            {
                GetDateWiseTrip = dateWiseTrips,
                FromLocation=from.Location,
                ToLocation=to.Location
            };

            return View(s);
        }
        //public ActionResult SearchResult()
        //{
        //    return View();
        //}
    }
}