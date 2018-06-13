using OBTM.Core.Models;
using OBTM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineBusTicketManagement.Controllers
{
    public class DateWiseTripController : Controller
    {
        DateWiseTripService dateWiseTripService = new DateWiseTripService();
        BusOperatorService busOperatorService = new BusOperatorService();
        RouteService routeService = new RouteService();
        TripBaseService tripBaseService = new TripBaseService();
        BookingTicketService bookingTicketService = new BookingTicketService();

        public ActionResult Index()
        {
            List<DateWiseTrip> dateWiseTripList = new List<DateWiseTrip>();
            ViewBag.BusOperator = new SelectList(busOperatorService.GetAll(), "Id", "Name");
            return View("DateWiseTrip", dateWiseTripList);
        }

        public ActionResult GetDateWiseTripList(string tripId)
        {
            int tripID = Convert.ToInt32(tripId);
            IEnumerable<DateWiseTrip> dateWiseTripList = dateWiseTripService.GetDateWiseTrip(tripID);
            ViewBag.BusOperator = new SelectList(busOperatorService.GetAll(), "Id", "Name");
            return View("DateWiseTrip", dateWiseTripList);
        }

        public ActionResult Save(DateWiseTrip dateWiseTrip, string tripId)
        {
            int tripID = Convert.ToInt32(tripId);
            if (ModelState.IsValid)
            {
                if (dateWiseTrip.Id == 0)
                {
                    dateWiseTrip.TripBaseId = tripID;
                    dateWiseTrip.IsDeleted = false;
                    dateWiseTrip.IsActive = true;
                    dateWiseTrip.CreatedOn = DateTime.Now;
                    dateWiseTripService.Save(dateWiseTrip);
                    bookingTicketService.CreateBookingTickets(dateWiseTrip.NoOfSeat, dateWiseTrip.Id);
                }
                else
                {
                    dateWiseTrip.UpdatedOn = DateTime.Now;
                    dateWiseTripService.Update(dateWiseTrip);
                }
               
            }
            return RedirectToAction("Index");
        }

        public JsonResult GetRoutes(string busOperatorID)
        {
            int busOperatorId = Convert.ToInt32(busOperatorID);
            var routeList = routeService.GetRefinedRoutes(busOperatorId).Select(m=> new{m.Id, m.RouteName });
            return Json(routeList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTrips(string routeID, string busOperatorID)
        {
            int routeId = Convert.ToInt32(routeID);
            int busOperatorId = Convert.ToInt32(busOperatorID);
            var tripList = tripBaseService.GetRefinedTrips(routeId, busOperatorId).Select(m=> new { m.Id, m.DepartureTime.TimeOfDay});
            return Json(tripList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            DateWiseTrip dateWiseTrip = new DateWiseTrip();
            ViewBag.BusOperator = new SelectList(busOperatorService.GetAll(), "Id", "Name");
            return View("CreateDateWiseTrip", dateWiseTrip);
        }

        public ActionResult Edit(int id)
        {
            DateWiseTrip dateWiseTrip = dateWiseTripService.GetById(id);
            return View("EditDateWiseTrip", dateWiseTrip);
        }
    }
}