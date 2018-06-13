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
    public class RouteController : Controller
    {
        RouteService rs = new RouteService();
        RoutePointsService rps = new RoutePointsService();
        OperatorRouteMapService orm = new OperatorRouteMapService();
        BusOperatorService bos = new BusOperatorService();
        LocationsService ls = new LocationsService();

        // GET: Route
        OBTMDbContext context = new OBTMDbContext();
        public ActionResult Index()
        {

            //Route r = new Route {
            //    RouteName = "D-K-J"
            //};
            //rs.Save(r);
            //OperatorRouteMap op = new OperatorRouteMap
            //{
            //    BusOperatorId = 1,
            //    RouteId= r.Id
            //};
            //orm.Save(op);
            //rps.Save(new RoutePoints() { RouteId = 1, LocationId = 1, SequenceId=1});
            //rps.Save(new RoutePoints() { RouteId = 1, LocationId = 2 ,SequenceId=2});
            //rps.Save(new RoutePoints() { RouteId = 1, LocationId = 3 , SequenceId=3});

            ViewBag.BusOperatorList = new SelectList(context.BusOperators, "Id", "Name");
            ViewBag.LocationList = new SelectList(context.Locations, "Id", "Location");
            ViewBag.ExistingRouteList = new SelectList(context.Routes, "Id", "RouteName");
            var model = bos.GetAll();
            return View(model);
            

        }
        public ActionResult SaveRoute(Route r)
        {
            RouteService rs = new RouteService();
            rs.Save(r);
            return View("Index");
        }
        public ActionResult DeleteRoute(int id)
        {
            RouteService rs = new RouteService();
            rs.Delete(id);
            return View("Index");
        }
        //public ActionResult Edit()
        //{

        //}
        public ActionResult CreateRoute()
        {
            ViewBag.BusOperatorList = new SelectList(context.BusOperators, "Id", "Name");
            ViewBag.LocationList = new SelectList(context.Locations, "Id", "Location");
            ViewBag.ExistingRouteList = new SelectList(context.Routes, "Id", "RouteName");
            return View("AddRouteView");
        }

        public ActionResult AddRouteView(RouteView routeView)
        {
            ViewBag.BusOperatorList = new SelectList(context.BusOperators, "Id", "Name");
            ViewBag.LocationList = new SelectList(context.Locations, "Id", "Location");
            ViewBag.ExistingRouteList = new SelectList(context.Routes, "Id", "RouteName");

            if (routeView.Routes.Id != 0)
            {
                #region for selected existing route
                OperatorRouteMap op = new OperatorRouteMap
                {
                    RouteId = routeView.Routes.Id,
                    BusOperatorId = routeView.BusOperatorId
                };
                orm.Save(op);
                #endregion
            }
            else
            {
                #region New Route Adding
                List<string> Routes = new List<string>();
                var FromLocation = ls.GetById(routeView.From);
                Routes.Add(FromLocation.Location);


                foreach (var item in routeView.Via)
                {
                    var ViaLocation = ls.GetById(item);
                    Routes.Add(ViaLocation.Location);
                }
                var ToLocation = ls.GetById(routeView.To);
                Routes.Add(ToLocation.Location);

                var name = string.Join("-", Routes);
                Route r = new Route()
                {
                    RouteName = name.ToString()
                };
                rs.Save(r);
                #region IsReverse is true
                if (routeView.IsReverse == true)
                {
                   Routes.Reverse();
                    var nameReverse = string.Join("-", Routes);
                    Route rr = new Route()
                    {
                        RouteName = nameReverse.ToString(),
                        ReverseId = r.Id
                    };
                    rs.Save(rr);

                    OperatorRouteMap opReverse = new OperatorRouteMap
                    {
                        RouteId = rr.Id,
                        BusOperatorId = routeView.BusOperatorId
                    };
                    orm.Save(opReverse);
                }
                #endregion
                OperatorRouteMap op = new OperatorRouteMap
                {
                    RouteId = r.Id,
                    BusOperatorId = routeView.BusOperatorId
                };
                orm.Save(op);

                int j = 1;
                rps.Save(new RoutePoints() { RouteId = r.Id, LocationId = routeView.From, SequenceId = j, IsFrom = true });
                foreach (var item in routeView.Via)
                {
                    j++;
                    rps.Save(new RoutePoints() { RouteId = r.Id, LocationId = (int)item, SequenceId = j });
                }

                rps.Save(new RoutePoints() { RouteId = r.Id, LocationId = routeView.To, SequenceId = ++j, IsTo = true });
                #endregion
            }


            return View();
        }
   }
}
