using OST_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OST_Inventory.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account Model)
        {

            if(String.IsNullOrEmpty(Model.UserName) && String.IsNullOrEmpty(Model.Password))
                ViewBag.Message = "Login Neended";

            if (Model.UserName == "Raian" && Model.Password == "123")
            {
                Session["User"] = Model.UserName;
                ViewBag.Message = "Login Success";
               RedirectToAction("DashBoard", "Home");
            }
            else
            {
                ViewBag.Message = "Login Failed";
              
            }
            return View();
        }
    }
}