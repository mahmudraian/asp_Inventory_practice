using OST_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OST_Inventory.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult DashBoard()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult SaveEquipment(FormCollection formCollection, string btnSubmit)
        {
            Session["sessionMsg"] = "";
            if (btnSubmit == "save")
            {
                string Name = formCollection["txtName"].ToString();
                int Quantity = Convert.ToInt32(formCollection["txtQuantity"].ToString());
                int Stock = Convert.ToInt32(formCollection["txtstock"].ToString());


                int result = Equipment.SaveEquipmrnt(Name, Quantity, Stock);
                if (result == 1)
                {
                    Session["sessionMsg"] = "Save Successfully";
                }
            }
            return RedirectToAction("DashBoard");
        }

        public ActionResult SaveMember(FormCollection formCollection, string btnSubmit) {
            Session["sessionMsg"] = "";
            int result =0;

            if (btnSubmit == "save")
            {
                string UserName = formCollection["txtUserName"].ToString();
                string UserPassword = formCollection["txtPassword"].ToString();
                string Role = formCollection["txtRole"].ToString();
                int resule = Member.SaveMember(UserName, UserPassword, Role);
                if (result == 1)
                {
                    Session["sessionMsg"] = "Save Successfully";
                }
            }
            return RedirectToAction("DashBoard");

        }



    }
}