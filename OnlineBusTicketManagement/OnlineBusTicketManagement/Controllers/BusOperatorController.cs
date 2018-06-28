using OBTM.Core.Models;
using OBTM.Service;
using OnlineBusTicketManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicketManagement.Controllers
{
    [AuthorizeWithSession]
    public class BusOperatorController : Controller
    {
        // GET: BusOperator
        BusOperatorService bo = new BusOperatorService();
        OperatorRouteMapService orms = new OperatorRouteMapService();
        public ActionResult Index()
        {
            var preBusList = bo.GetAllBusOperators();
            List<BusOperator> postBusList = new List<BusOperator>();
            foreach (var item in preBusList)
            {
                if (item.IsDeleted == null || item.IsDeleted == false)
                {
                    postBusList.Add(item);
                }
            }
            return View(postBusList);
        }
        public ActionResult SaveBusOperator(BusOperator model)
        {
            var id = model.Id;
            if (model.Id==0)
            {
                
                BusOperator b = new BusOperator()
                {
                    Name = model.Name,
                    Email = model.Email
                };
                bo.Save(b);
            }

            else
            {
                //bo.SaveEditedBus(model);
                bo.Update(model);
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
            
            
            BusOperator b = new BusOperator();
            b= bo.GetById(id);
            return View("CreateEditBus", b);
        }

        public ActionResult Delete(int id)
        {
            
            bo.DeleteBusSoft(id);
            orms.DeleteOperatorRouteSoft(id);
            return RedirectToAction("Index");
        }

    }
}