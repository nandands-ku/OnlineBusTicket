using OBTM.Core.Models;
using OBTM.Service;
using OnlineBusTicketManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineBusTicketManagement.Controllers
{
    [AuthorizeWithSession]
    public class DateWiseTripController : Controller
    {
        DateWiseTripService dateWiseTripService = new DateWiseTripService();
        BusOperatorService busOperatorService = new BusOperatorService();
        RouteService routeService = new RouteService();
        TripBaseService tripBaseService = new TripBaseService();
        BookingTicketService bookingTicketService = new BookingTicketService();
        BaseService baseService = new BaseService();

        public ActionResult Index()
        {
            IEnumerable<DateWiseTrip> dateWiseTripList = new List<DateWiseTrip>();
            DateWiseTripView dateWiseTripView = new DateWiseTripView
            {
                DateWiseTripList = dateWiseTripList,
                BusOperator = new BusOperator(),
                Route = new Route(),
                TripBase = new TripBase()
            };
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

        public ActionResult SaveNew(DateWiseTripCreateView dateWiseTripCreateView, string tripId)
        {
            int tripID = Convert.ToInt32(tripId);

            if (ModelState.IsValid)
            {
                DateWiseTrip dateWiseTrip = new DateWiseTrip
                {
                    Date = dateWiseTripCreateView.Date,
                    Fare = dateWiseTripCreateView.Fare,
                    NoOfSeat = dateWiseTripCreateView.NoOfSeat,
                    TripBaseId = tripID,
                    IsDeleted = false,
                    IsActive = true
                };
                dateWiseTripService.Save(dateWiseTrip);
                bookingTicketService.CreateBookingTickets(dateWiseTrip.NoOfSeat, dateWiseTrip.Id);           
            }
            DateWiseTripCreateView _dateWiseTripCreateView = new DateWiseTripCreateView
            {
                TripId = dateWiseTripCreateView.TripId,
                BusOperatorId = dateWiseTripCreateView.BusOperatorId,
                RouteId = dateWiseTripCreateView.RouteId
            };

            ViewBag.BusOperator = new SelectList(busOperatorService.GetAll(), "Id", "Name");
            return View("CreateDateWiseTrip", _dateWiseTripCreateView);
        }

        public ActionResult SaveEdited(DateWiseTripEditView dateWiseTripEditView)
        {
            DateWiseTrip dateWiseTrip = new DateWiseTrip
            {
                Id = dateWiseTripEditView.DateWiseTripId,
                Date = dateWiseTripEditView.Date,
                Fare = dateWiseTripEditView.Fare,
                NoOfSeat = dateWiseTripEditView.NoOfSeat,
                TripBaseId = dateWiseTripEditView.TripId,
                CreatedBy = dateWiseTripEditView.CreatedBy,
                CreatedOn = dateWiseTripEditView.CreatedOn,
                IsActive = dateWiseTripEditView.IsActive,
                IsDeleted = dateWiseTripEditView.IsDeleted
            };

            DateWiseTrip tempDateWiseTrip = dateWiseTripService.GetById(dateWiseTripEditView.DateWiseTripId);

            if (tempDateWiseTrip.NoOfSeat<dateWiseTripEditView.NoOfSeat)
            {
                bookingTicketService.ExtendBookingTickets(tempDateWiseTrip.NoOfSeat + 1, (dateWiseTripEditView.NoOfSeat - tempDateWiseTrip.NoOfSeat), dateWiseTripEditView.DateWiseTripId);
                dateWiseTripService.Update(dateWiseTrip);
            }
            else if (tempDateWiseTrip.NoOfSeat > dateWiseTripEditView.NoOfSeat)
            {
                bookingTicketService.ReduceBookingTickets((tempDateWiseTrip.NoOfSeat-dateWiseTripEditView.NoOfSeat), dateWiseTripEditView.DateWiseTripId);
                dateWiseTripService.Update(dateWiseTrip);
            }
            else
            {
                dateWiseTripService.Update(dateWiseTrip);
            }
            

            IEnumerable<DateWiseTrip> dateWiseTripList = dateWiseTripService.GetDateWiseTrip(dateWiseTripEditView.TripId);
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

        public JsonResult CanReduceSeatAvailability(int NoOfSeat, int DateWiseTripId)
        {

            if (dateWiseTripService.IsSeatsReducible(NoOfSeat, DateWiseTripId))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }    
            else
            {
                string suggestion = String.Format($"You can reduce available seat upto {dateWiseTripService.GetNumOfNotBookedSeats(DateWiseTripId)}.");
                return Json(suggestion, JsonRequestBehavior.AllowGet);
            } 
            
        }

        public ActionResult Create(int busOperatorId, int routeId, int tripId)
        {
            DateWiseTripCreateView dateWiseTripEditView = new DateWiseTripCreateView
            {
                BusOperatorId = busOperatorId,
                RouteId = routeId,
                TripId = tripId
            };
            ViewBag.BusOperator = new SelectList(busOperatorService.GetAll(), "Id", "Name");
            return View("CreateDateWiseTrip", dateWiseTripEditView);
        }

        public ActionResult Edit(int id, int busOperatorId, int routeId, int tripId)
        {
            DateWiseTrip dateWiseTrip = dateWiseTripService.GetById(id);
            DateWiseTripEditView dateWiseTripEditView = new DateWiseTripEditView
            {
                DateWiseTripId = dateWiseTrip.Id,
                Date = dateWiseTrip.Date,
                NoOfSeat = dateWiseTrip.NoOfSeat,
                Fare = dateWiseTrip.Fare,
                IsActive = dateWiseTrip.IsActive,
                IsDeleted = dateWiseTrip.IsDeleted,
                CreatedBy = dateWiseTrip.CreatedBy,
                CreatedOn = dateWiseTrip.CreatedOn,
                UpdatedBy = dateWiseTrip.UpdatedBy,
                UpdatedOn = dateWiseTrip.UpdatedOn,
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