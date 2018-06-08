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
        public ActionResult Index()
        {
            
            //TripBase tb = new TripBase() {
            //    BusType = "AC",
            //    DepartureTime = TimeSpan.Parse("10:11"),
            //    RouteId = 1,    
            //};
            //tbs.Save(tb);
            ViewBag.BusOperatorList = bo.GetAll();
            return View();
        }

        [HttpGet]
        public JsonResult GetBusRoute(int id)
        {
            var routesIdList=orms.GetAll().Where(m=>m.BusOperatorId==id).Select(m=>m.Route).ToList();
            //var routesIdList=
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<OperatorRouteMap>));
            //MemoryStream ms = new MemoryStream();
            //ser.WriteObject(ms, routesIdList);
            //StreamReader sr = new StreamReader(ms);
            //routesIdList = sr.ReadToEnd();
            //sr.Close();
            //ms.Close();
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //string result = jss.Serialize(routesIdList);
            var rrr=rs.GetAll().ToList();


            return Json(routesIdList, JsonRequestBehavior.AllowGet);
        }
    }
}