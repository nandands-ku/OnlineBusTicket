using OBTM.Core.Models;
using OBTM.Service;
using OnlineBusTicketManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public ActionResult ViewUsers()
        {
            return View("UserList", userService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            var ifUserNameExists = userService.GetAll().Where(m => m.UserName == user.UserName).ToList();
            var ifUserMailExists = userService.GetAll().Where(m => m.Email == user.Email).ToList();

            if (ifUserNameExists.Count > 0 || ifUserMailExists.Count > 0)
            {
                return RedirectToAction("Create");
            }

            else
            {
                byte[] hashedPassword = GetHashedPassword(user.Password + user.UserName);
                user.Password = GetStringFromHash(hashedPassword);
                userService.Save(user);
                return RedirectToAction("ViewUsers");
            }
            
        }

        public ActionResult LogIn(UserView user)
        {
            byte[] hashedPassword = GetHashedPassword(user.Password + user.UserName);
            user.Password = GetStringFromHash(hashedPassword);
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

        public ActionResult Delete(int id)
        {
            userService.Delete(id);
            return RedirectToAction("ViewUsers");
        }

        public ActionResult LogOut()
        {
            HttpContext.Session["User"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult ChangePassWord()
        {
            return View();
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        private static byte[] GetHashedPassword(string userPassword)
        {
            byte[] hashedPassword;
            byte[] passwordByteStream;

            SHA512 sHA512 = new SHA512Managed();

            passwordByteStream = Encoding.UTF8.GetBytes(userPassword);
            hashedPassword = sHA512.ComputeHash(passwordByteStream);

            return hashedPassword;
        }


    }
}