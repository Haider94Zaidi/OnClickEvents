using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OnClickEvents.Controllers
{
    public class VendorController : Controller
    {
        DalClass dal = new DalClass();
        string query = "";
        
         
        public ActionResult DashBoard(string venemail,string venpassword)
        {
            ViewResult v = null;

            if (IsValidEmail(venemail))
            {
                if (venpassword != "" && venpassword.Length >= 6)
                {
                    try
                    {
                        dal.CheckConnection();
                        Object name;
                        query = "Call retrievevendor('" + venemail + "','" + venpassword + "');";
                        name = dal.ExecuteScalar(query);
                        if (name.ToString() != "")
                        {
                            return View();
                        }
                        else
                        {
                            Response.Redirect("/Home/Index");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("/Home/Index");
                    }
                }
                else
                {
                    Response.Redirect("/Home/Index");
                }
            }
            else
            {
                Response.Redirect("/Home/Index");
            }
            return null;
        }

        public ActionResult RegisterVenue() {
            return View();
        }

        public ActionResult AddFood()
        {
            return View();
        }


        [NonAction]
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}