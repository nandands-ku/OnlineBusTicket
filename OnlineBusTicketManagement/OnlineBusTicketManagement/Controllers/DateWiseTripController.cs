using OBTM.Core.Models;
using OBTM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicketManagement.Controllers
{
    public class DateWiseTripController : Controller
    {
        GenericService<DateWiseTrip> genericServiceDateWiseTrip = new GenericService<DateWiseTrip>();
        GenericService<BusOperator> genericServiceBusOperator = new GenericService<BusOperator>();
        GenericService<Route> genericServiceRoute = new GenericService<Route>();
        GenericService<TripBase> genericServiceTripbase = new GenericService<TripBase>();


        // GET: DateWiseTrip
        //Revise code in this action
        public ActionResult Index()
        {
            List<DateWiseTrip> dateWiseTripList = new List<DateWiseTrip>(); //genericServiceDateWiseTrip.GetAll();
           // ViewBag.BusOperator = new SelectList(genericServiceBusOperator.GetAll(), "Id", "Name");
            //Route and Trip should be retrived with AJAX call in the view, not by ViewBag, change the implmntn
            //ViewBag.Route = new SelectList(genericServiceRoute.GetAll(), "Id", "RouteName");
            //ViewBag.Trip = new SelectList(genericServiceTripbase.GetAll(), "Id", "DepartureTime");
            return View("DateWiseTrip", dateWiseTripList);
        }

        public JsonResult GetBusOperators()
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRoutes()
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            DateWiseTrip dateWiseTrip = new DateWiseTrip();
            return View("CreateDateWiseTrip", dateWiseTrip);
        }

        public ActionResult Edit(int id)
        {
            DateWiseTrip dateWiseTrip = genericServiceDateWiseTrip.GetById(id);
            return View("EditDateWiseTrip", dateWiseTrip);
        }
    }
}