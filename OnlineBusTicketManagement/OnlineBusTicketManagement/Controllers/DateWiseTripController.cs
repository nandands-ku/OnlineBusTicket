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
            IEnumerable<DateWiseTrip> dateWiseTripList = new List<DateWiseTrip>();
            DateWiseTripView dateWiseTripView = new DateWiseTripView();
            dateWiseTripView.DateWiseTripList = dateWiseTripList;
            dateWiseTripView.BusOperator = new BusOperator();
            dateWiseTripView.Route = new Route();
            dateWiseTripView.TripBase = new TripBase();
            ViewBag.BusOperator = new SelectList(busOperatorService.GetAll(), "Id", "Name");
            return View("DateWiseTrip", dateWiseTripView);
        }

        public ActionResult GetDateWiseTripList(DateWiseTripView dateWiseTripView)
        {
            IEnumerable<DateWiseTrip> dateWiseTripList = dateWiseTripService.GetDateWiseTrip(dateWiseTripView.TripBase.Id);
            ViewBag.BusOperator = new SelectList(busOperatorService.GetAll(), "Id", "Name");
            DateWiseTripView _dateWiseTripView = new DateWiseTripView
            {
                DateWiseTripList = dateWiseTripList,
                BusOperator = dateWiseTripView.BusOperator,
                Route = dateWiseTripView.Route,
                TripBase = dateWiseTripView.TripBase
            };


            return View("DateWiseTrip", _dateWiseTripView);
        }

        public ActionResult SaveNew(DateWiseTrip dateWiseTrip, string tripId)
        {
            int tripID = Convert.ToInt32(tripId);
            if (ModelState.IsValid)
            {  
                 dateWiseTrip.TripBaseId = tripID;
                 dateWiseTrip.IsDeleted = false;
                 dateWiseTrip.IsActive = true;
                 dateWiseTrip.CreatedOn = DateTime.Now;
                 dateWiseTripService.Save(dateWiseTrip);
                 bookingTicketService.CreateBookingTickets(dateWiseTrip.NoOfSeat, dateWiseTrip.Id);           
            }
            return RedirectToAction("Create");
        }

        public ActionResult SaveEdited(DateWiseTripEditView dateWiseTripEditView)
        {
            dateWiseTripEditView.DateWiseTrip.UpdatedOn = DateTime.Now;
            dateWiseTripService.Update(dateWiseTripEditView.DateWiseTrip);

            IEnumerable<DateWiseTrip> dateWiseTripList = dateWiseTripService.GetDateWiseTrip(dateWiseTripEditView.DateWiseTrip.TripBaseId);
            ViewBag.BusOperator = new SelectList(busOperatorService.GetAll(), "Id", "Name");
            DateWiseTripView _dateWiseTripView = new DateWiseTripView
            {
                DateWiseTripList = dateWiseTripList,
                BusOperator = new BusOperator { Id= dateWiseTripEditView.BusOperatorId },
                Route = new Route { Id = dateWiseTripEditView.RouteId },
                TripBase = new TripBase { Id = dateWiseTripEditView.TripId }
            };

            return View("DateWiseTrip", _dateWiseTripView);
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

        public ActionResult Edit(int id, int busOperatorId, int routeId, int tripId)
        {
            DateWiseTrip dateWiseTrip = dateWiseTripService.GetById(id);
            DateWiseTripEditView dateWiseTripEditView = new DateWiseTripEditView
            {
                DateWiseTrip = dateWiseTrip,
                BusOperatorId = busOperatorId,
                RouteId = routeId,
                TripId = tripId
            };
            return View("EditDateWiseTrip", dateWiseTripEditView);
        }

        public ActionResult Delete(int id, int busOperatorId, int routeId, int tripId)
        {
            dateWiseTripService.SoftDelete(id);
            IEnumerable<DateWiseTrip> dateWiseTripList = dateWiseTripService.GetDateWiseTrip(tripId);
            ViewBag.BusOperator = new SelectList(busOperatorService.GetAll(), "Id", "Name");

            DateWiseTripView _dateWiseTripView = new DateWiseTripView
            {
                DateWiseTripList = dateWiseTripList,
                BusOperator = new BusOperator { Id = busOperatorId},
                Route = new Route { Id = routeId},
                TripBase = new TripBase { Id = tripId}
            };

            return View("DateWiseTrip", _dateWiseTripView);
        }
    }
}