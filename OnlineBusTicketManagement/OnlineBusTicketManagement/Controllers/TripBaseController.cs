using OBTM.Core.Models;
using OBTM.Service;
using OnlineBusTicketManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineBusTicketManagement.Controllers
{

    [AuthorizeWithSession]
    public class TripBaseController : Controller
    {
        TripBaseService tripBaseService = new TripBaseService();
        BusOperatorService busOperatorService = new BusOperatorService();
        RouteService routeService = new RouteService();
        OperatorRouteMapService operatorRouteMapService = new OperatorRouteMapService();

        // GET: TripBase
        public ActionResult Index(int operatorId=0, int routeId=0,bool result = false)
        {
            TripBase trip = new TripBase() { BusOperatorId = operatorId , RouteId = routeId };
            ViewBag.BusOperatorList = new SelectList(busOperatorService.GetAll().Where(m => m.IsDeleted != true).ToList(), "Id", "Name");
            ViewBag.actionStatus = result;
            return View(trip);
        }

        [HttpGet]
        public JsonResult GetBusRoute(int operatorId)
        {
            var routesIdList = operatorRouteMapService.GetAll().Where(m => m.IsDeleted != true && m.BusOperatorId == operatorId).Select(m => new { m.Route.Id, m.Route.RouteName }).ToList();
            return Json(routesIdList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetBusTrips(int operatorId, int routeId)
        {
            IEnumerable<TripBase> tripList = tripBaseService.GetRefinedTrips(routeId, operatorId);
            ViewBag.BusOperatorId = operatorId;
            ViewBag.RouteId = routeId;
            return PartialView("TripPartial", tripList);
        }


        public ActionResult CreateTrip(int operatorId, int routeId)
        {
            ViewBag.BusOperatorList = new SelectList(busOperatorService.GetAll().Where(m => m.IsDeleted != true).ToList(), "Id", "Name");
            TripBase temp = new TripBase() { BusOperatorId = operatorId, RouteId = routeId };
            return View("TripInfo", temp);
        }


        [HttpPost]
        public ActionResult Create(TripBase trip)
        {
            bool actionStatus = false;
            if (trip.Id == 0)
                actionStatus = tripBaseService.Save(trip).Success;
              
            else
                actionStatus = tripBaseService.Update(trip).Success;   
            return RedirectToAction("Index",new { operatorId=trip.BusOperatorId, routeId=trip.RouteId, result = actionStatus });

        }

        public ActionResult Edit(int tripId)
        {
            ViewBag.BusOperatorList = new SelectList(busOperatorService.GetAll().Where(m => m.IsDeleted != true).ToList(), "Id", "Name");
            return View("TripInfo", tripBaseService.GetById(tripId));
        }

        public ActionResult Delete(int tripId)
        {
            var actionStatus=tripBaseService.Delete(tripId).Success;
            TripBase trip = tripBaseService.GetById(tripId);
            return RedirectToAction("Index", new { operatorId = trip.BusOperatorId, routeId = trip.RouteId,action= actionStatus });
        }

    }
}
