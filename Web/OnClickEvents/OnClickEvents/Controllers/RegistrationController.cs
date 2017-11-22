using OnClickEvents.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace OnClickEvents.Controllers
{
    public class RegistrationController : Controller
    {
        DalClass dal = new DalClass();
        string query = "";
        public ActionResult Register() {
            return View();
        }

        #region "Registration / SignUp"

        #region "customer"
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
        #endregion

        #region "vendor"
        [HttpPost]
        public ActionResult vendorRegister(string Name,string Email,string Password,string Address,string Contact,string Cnic,string Account) {

            string result="";
            Vendor v = new Vendor();
            v.Name = Name;
            v.Email = Email;
            v.Password = Password;
            v.Address = Address;
            v.Contact = Contact;
            v.CNIC = Convert.ToInt64(Cnic);
            v.Account = Account;

            query = "Insert into vendor_owner(OwnerName,OwnerEmail,OwnerAddress,OwnerContact,OwnerPwd,OwnerCNIC,OwnerAccount) values('" + v.Name + "','" + v.Email + "','" + v.Address + "','" + v.Contact + "','" + v.Password + "'," + v.CNIC + ",'" + v.Account + "')";
            try {
                if (dal.ExecuteData(query) == "1")
                {
                    result = "success";
                }
                else {
                    result = "failed";
                }
            }
            catch (Exception ex) {
               
            }

           return Json(result);
        }
        #endregion
        
        #endregion




        [HttpPost]
        public ActionResult Signin(string Email, string Pwd) {
            string s = "Yes Signed In";
            return Json(s);
        }


       
    }
}