using OnClickEvents.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Configuration;

namespace OnClickEvents.Controllers
{
    public class RegistrationController : Controller
    {
        DalClass dal = new DalClass();
        string query = "";
        public ActionResult Register() {
            return View();
        }

        // GET: Registration
        [HttpPost]
        public ActionResult Registering(string Name,string Email,string Contact,string Password,string DOB)
        {
            string result = "";
            try
            {
                Customer c = new Customer();
                
                c.Name = Name;
                c.Email = Email;
                c.Password = Password;
                c.Contact = Contact;
                c.DOB = DOB;
                c.CNIC = 0;
                c.Address = "";
                c.Status = "";
                try
                {
                    if (dal.CheckConnection())
                    {
                        query = "Insert into Customer(CName,CEmail,CPwd,CCnic,CAddress,CStatus,Cdob) values('" + c.Name + "','" + c.Email + "','" + c.Password + "'," + c.CNIC + ",'" + c.Address + "','" + c.Status + "','" + c.DOB + "')";

                        if (dal.ExecuteData(query) == "1")
                        {
                            result = "Registered Successfully";
                        }
                        else
                        {
                            result = "Problem Occured During Registration";
                        }
                    }
                    else {
                        result = "DataBase Down temporarily";
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            catch (Exception ex) {
                result = ex.Message.ToString();
            }

            return Json(result);
        }


        [HttpPost]
        public ActionResult Signin(string Email, string Pwd) {
            string s = "Yes Signed In";
            return Json(s);
        }


       
    }
}