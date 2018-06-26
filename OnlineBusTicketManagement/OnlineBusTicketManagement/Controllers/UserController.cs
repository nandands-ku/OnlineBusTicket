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
    [AuthorizeWithSession]
    public class UserController : Controller
    {
        UserService userService = new UserService();
        // GET: User
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View("LogIn");
        }

        public ActionResult ViewDashBoard()
        {
            return View("DashBoard");
        }

        public ActionResult ViewUsers()
        {
            return View("UserList", userService.GetAll().Where(m => m.IsDeleted != true));
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
                user.Password = GetHashedPassword(user.Password + user.UserName);
                userService.Save(user);
                return RedirectToAction("ViewUsers");
            }

        }

        [AllowAnonymous]
        public ActionResult LogIn(UserView user)
        {
            user.Password = GetHashedPassword(user.Password + user.UserName);
            var validUser = userService.GetAll().Where(m => m.UserName == user.UserName && m.Password == user.Password).ToList();
            if (validUser.Count > 0)
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

        public ActionResult ChangePassWord(int id)
        {
            ChangePasswordView changePasswordViewModel = new ChangePasswordView
            {
                UserId = id
            };
            return View(changePasswordViewModel);

        }

        public ActionResult ChangePasswordConfirmed(ChangePasswordView changePasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User();

                user = userService.GetById(changePasswordViewModel.UserId);

                string oldPassword = changePasswordViewModel.OldPassword;
                string oldPasswordHash = GetHashedPassword(oldPassword + user.UserName);

                if (oldPasswordHash == user.Password)
                {
                    user.Password = GetHashedPassword(userPassword: changePasswordViewModel.ConfirmPassword + user.UserName);
                    userService.Update(user);
                    return RedirectToAction("ViewUsers");
                }
                else
                {
                    changePasswordViewModel.SubmissionMessage = "Password wrong! Enter Correct password";
                    return View("ChangePassWord", changePasswordViewModel);
                }
            }
            else
            {
                return View("ChangePassWord", changePasswordViewModel);
            }


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

        private static string GetHashedPassword(string userPassword)
        {
            byte[] hashedPasswordBytes;
            byte[] passwordByteStream;

            SHA512 sHA512 = new SHA512Managed();

            passwordByteStream = Encoding.UTF8.GetBytes(userPassword);
            hashedPasswordBytes = sHA512.ComputeHash(passwordByteStream);
            string hashedPassword = GetStringFromHash(hashedPasswordBytes);

            return hashedPassword;
        }


        [HttpPost]
        public JsonResult IsUserNameExist(string UserName)
        {

            return Json(!userService.IsExist(UserName));
        }

        [HttpPost]
        public JsonResult IsEmailExist(string Email)
        {

            return Json(!userService.IsExist(Email));
        }

    }
}