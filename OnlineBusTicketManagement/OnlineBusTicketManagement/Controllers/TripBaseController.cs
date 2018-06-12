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
            ViewBag.BusOperatorList = bo.GetAll();
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
            return PartialView("TripPartial", tripList);
        }

        
        public ActionResult Create()
        {
            ViewBag.BusOperatorList = new SelectList(bo.GetAll(),"Id","Name");
            return View("TripInfo");
        }


        [HttpPost]
        public ActionResult Create(TripBase trip)
        {
            tbs.Save(trip);
            return RedirectToAction("Index",trip);
            
        }
      
        public ActionResult Edit(int Id)
        {
            ViewBag.BusOperatorList = new SelectList(bo.GetAll(), "Id", "Name");
            return View("TripInfo", tbs.GetById(Id));
        }

        [HttpPost]
        public ActionResult Edit(TripBase trip)
        {
            tbs.Update(trip);
            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(int Id)
        {
            tbs.Delete(Id);
            return RedirectToAction("Index");
        }

    }
}



//IEnumerable<BusType> busTypes = Enum.GetValues(typeof(BusType))
//                                            .Cast<BusType>();

//IEnumerable<SelectListItem>  selectList = from bus in busTypes
//                                          select new SelectListItem
//                    {
//                        Text = bus.ToString(),
//                        Value = ((int)bus).ToString()
//                    };