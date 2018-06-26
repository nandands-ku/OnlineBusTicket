using OBTM.Core.Models;
using OBTM.DataAccess;
using OBTM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OnlineBusTicketManagement.Controllers
{
    public class BusSearchController : Controller
    {
        RoutePointsService rps = new RoutePointsService();
        TripBaseService tbs = new TripBaseService();
        DateWiseTripService dws = new DateWiseTripService();
        LocationsService ls = new LocationsService();
        BookingTicketService bts = new BookingTicketService();
        OBTMDbContext context = new OBTMDbContext();

        public List<TripBase> tripBases = new List<TripBase>();
        public List<DateWiseTrip> dateWiseTrips = new List<DateWiseTrip>();
        public List<TripBase> tripBaseFilter = new List<TripBase>();
        public List<DateWiseTrip> dateWiseTripFilter = new List<DateWiseTrip>();
        // GET: BusSearch
        public List<BusOperator> busOperators = new List<BusOperator>();
        public List<int> availableSeat = new List<int>();

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
            //var temp = new List<int>() { 5, 10, 25 };
            ViewBag.Fare = dateWiseTripService.GetById(dateWiseTripId).Fare;
             var BookingTickets= bookingTicketService.GetAll().Where(m =>m.DateWiseTripId==dateWiseTripId&&m.IsDeleted!=true&& m.IsBooked != true && m.IsTempLocked != true).Select(m=>m.SeatName).ToList();
            ViewBag.SeatNoList = seatBaseService.GetAll().Where(m => BookingTickets.Contains(m.SeatName)).Select(m => m.Id).ToList();
            ViewBag.SeatNameList = seatBaseService.GetAll().Select(m => m.SeatName).ToList();
            ViewBag.DateWiseTripId = dateWiseTripId;
            //ViewBag.SeatList = temp;
            return View();
        }
       // [HttpPost]
        public ActionResult SearchResult(SearchBus searchBus)
        {
            ViewBag.BusOperatorList = new SelectList(context.BusOperators, "Id", "Name");
            ViewBag.LocationList = new SelectList(context.Locations, "Id", "Location");
            
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
             
                
            }
            foreach (var item in tripBases)
            {
                if (dws.GetDateWiseByTrip(item.Id, searchBus.DepartureDate) != null)
                {
                    dateWiseTrips.AddRange(dws.GetDateWiseByTrip(item.Id, searchBus.DepartureDate));
                    
                }
                    
            }

            foreach (var item in dateWiseTrips)
            {
                availableSeat.Add(bts.GetAvailableSeatByDateWise(item.Id));
            }

            SearchBus s = new SearchBus
            {
                GetDateWiseTrip = dateWiseTrips,
                FromLocation=from.Location,
                ToLocation=to.Location,
                noOfAvailableSeat=availableSeat            
            };

            return View(s);
        }
        [HttpPost]
        public ActionResult ModifySearch(SearchBus modifySearch)
        {
            return RedirectToAction("SearchResult", modifySearch);
        }
        

        //[HttpPost]
        //public JsonResult FilterSearchByBus(int busID, int fromLoc, int toLoc, DateTime date)
        //{
        //    int busOperator = Convert.ToInt32(busID);
        //    int from = Convert.ToInt32(fromLoc);
        //    int to = Convert.ToInt32(toLoc);
        //    DateTime dateVal = Convert.ToDateTime(date);
        //    var routeList = rps.GetRoute(from, to);

        //    foreach (var item in routeList)
        //    {
        //        if (tbs.GetTripByRouteIdAndBus(item,busID) != null)
        //        {
        //            tripBaseFilter.AddRange(tbs.GetTripByRouteIdAndBus(item, busID));
        //        }


        //    }
        //    foreach (var item in tripBases)
        //    {
        //        if (dws.GetDateWiseByTrip(item.Id, dateVal) != null)
        //        {
        //            dateWiseTripFilter.AddRange(dws.GetDateWiseByTrip(item.Id, dateVal));

        //        }

        //    }
        //    return Json(dateWiseTripFilter, JsonRequestBehavior.AllowGet);
        //}

    }
}