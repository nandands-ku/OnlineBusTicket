using OBTM.Core.Models;
using OBTM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicketManagement.Controllers
{
    public class BusOperatorController : Controller
    {
        // GET: BusOperator
        public ActionResult Index()
        {
            BusOperatorService bo = new BusOperatorService();
            

            return View(bo.GetAllBusOperators());
        }
        public ActionResult SaveBusOperator(BusOperator model)
        {
            var id = model.Id;
            if (model.Id==0)
            {
                BusOperatorService bo = new BusOperatorService();
                BusOperator b = new BusOperator()
                {
                    Name = model.Name,
                    Email = model.Email
                };
                bo.Save(b);
            }

            else
            {
                BusOperatorService bo = new BusOperatorService();
                bo.SaveEditedBus(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult CreateBusOperator()
        {
            BusOperator b = new BusOperator();
            return View("CreateEditBus", b);
        }
        public ActionResult Edit(int id)
        {
            BusOperatorService bs = new BusOperatorService();
            
            BusOperator b = new BusOperator();
            b= bs.GetById(id);
            return View("CreateEditBus", b);
        }

    }
}