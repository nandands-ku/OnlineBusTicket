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
        public ActionResult Index(TripBase trip)
        {
            ViewBag.BusOperatorList = new SelectList(busOperatorService.GetAll().Where(m=>m.IsDeleted!=true).ToList(), "Id", "Name");
            return View(trip);
        }

        [HttpGet]
        public JsonResult GetBusRoute(int id)
        {
            var routesIdList = operatorRouteMapService.GetAll().Where(m => m.IsDeleted != true&& m.BusOperatorId == id).Select(m => new { m.Route.Id, m.Route.RouteName }).ToList();
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
            ViewBag.BusOperatorList = new SelectList(busOperatorService.GetAll().Where(m => m.IsDeleted != true).ToList(), "Id","Name");
            TripBase temp = new TripBase() { BusOperatorId = operatorId, RouteId = routeId};
            return View("TripInfo", temp);
        }


        [HttpPost]
        public ActionResult Create(TripBase trip)
        {
            if(trip.Id==0)
                tripBaseService.Save(trip);
            else
                tripBaseService.Update(trip);
            return RedirectToAction("Index",trip);
            
        }
      
        public ActionResult Edit(int Id)
        {
            ViewBag.BusOperatorList = new SelectList(busOperatorService.GetAll().Where(m => m.IsDeleted != true).ToList(), "Id", "Name");
            return View("TripInfo", tripBaseService.GetById(Id));
        }

        public ActionResult Delete(int Id)
        {
            tripBaseService.Delete(Id);
            TripBase temp = tripBaseService.GetById(Id);
            return RedirectToAction("Index", temp);
        }

    }
}
