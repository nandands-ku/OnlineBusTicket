using OBTM.Core.Models;
using OBTM.Service;
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
    public class TripBaseController : Controller
    {
        TripBaseService tbs = new TripBaseService();
        BusOperatorService bo = new BusOperatorService();
        RouteService rs = new RouteService();
        OperatorRouteMapService orms = new OperatorRouteMapService();

        // GET: TripBase
        public ActionResult Index(TripBase trip)
        {
            ViewBag.BusOperatorList = new SelectList(bo.GetAll(), "Id", "Name");
            return View(trip);
        }

        [HttpGet]
        public JsonResult GetBusRoute(int id)
        {
            var routesIdList = orms.GetAll().Where(m => m.BusOperatorId == id).Select(m => new { m.Route.Id, m.Route.RouteName }).ToList();

            return Json(routesIdList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetBusTrips(int operatorId, int routeId)
        {
            IEnumerable<TripBase> tripList = tbs.GetAll().Where(m => m.BusOperatorId == operatorId&&m.RouteId==routeId&&m.IsDeleted!=true).ToList();
            ViewBag.BusOperatorId = operatorId;
            ViewBag.RouteId = routeId;
            return PartialView("TripPartial", tripList);
        }

        
        public ActionResult CreateTrip(int operatorId, int routeId)
        {
            ViewBag.BusOperatorList = new SelectList(bo.GetAll(),"Id","Name");
            TripBase temp = new TripBase() { BusOperatorId = operatorId, RouteId = routeId};
            return View("TripInfo", temp);
        }


        [HttpPost]
        public ActionResult Create(TripBase trip)
        {
            if(trip.Id==0)
                tbs.Save(trip);
            else
                tbs.Update(trip);
            return RedirectToAction("Index",trip);
            
        }
      
        public ActionResult Edit(int Id)
        {
            ViewBag.BusOperatorList = new SelectList(bo.GetAll(), "Id", "Name");
            return View("TripInfo", tbs.GetById(Id));
        }

        public ActionResult Delete(int Id)
        {
            tbs.Delete(Id);
            TripBase temp = tbs.GetById(Id);
            return RedirectToAction("Index", temp);
        }

    }
}
