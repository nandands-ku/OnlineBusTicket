using OBTM.Core.Models;
using OBTM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicketManagement.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            UserService us = new UserService();
            User nandan = new User() {
                 UserName="Nandan",
                 Email="nandan.ku@gmail.com",
                 Password="1234",
                 
            };
            us.Save(nandan);
            return View();
        }
    }
}