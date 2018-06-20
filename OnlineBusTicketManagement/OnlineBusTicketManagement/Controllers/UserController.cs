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
    public class UserController : Controller
    {
        UserService userService = new UserService();
        // GET: User
        public ActionResult Index()
        {
            return View("LogIn");
        }

        [AuthorizeWithSession]
        public ActionResult ViewDashBoard()
        {
            return View("DashBoard");
        }



        public ActionResult LogIn(UserView user)
        {
            var validUser = userService.GetAll().Where(m => m.UserName == user.UserName && m.Password == user.Password).ToList();
            if(validUser.Count>0)
            {
                HttpContext.Session["User"] = user.UserName;
                return RedirectToAction("ViewDashBoard");
            }
            else
            {
                HttpContext.Session["User"] = null;
                return RedirectToAction("Index");
            }
               
        }


        public ActionResult LogOut()
        {
            HttpContext.Session["User"] = null;
            return RedirectToAction("Index");
        }

    }
}