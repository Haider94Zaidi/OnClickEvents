using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnClickEvents.Controllers
{
    
    public class VenueController : Controller
    {
        DalClass dal = new DalClass();
        string srcpath = System.Configuration.ConfigurationSettings.AppSettings.Get("srcpath");
        string archive = "\\Archive\\";
        string FullDir = "";
        // GET: Venue
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVenue() {

            string _sql = "";

            HttpFileCollectionBase images = Request.Files;
            int VendorID=1;
            string venuename = Request["venuename"].ToString();
            string address = Request["venueaddress"].ToString();
            long mobile = Convert.ToInt64(Request["venuemobile"].ToString());
            long phone = Convert.ToInt64(Request["venuephone"].ToString());
            string venuetype = Request["venuetype"].ToString();
            decimal longitude = Convert.ToDecimal(Request["Longitude"].ToString());
            decimal latitude = Convert.ToDecimal(Request["latitude"].ToString());
            string msg = "";
            if (dal.CheckConnection())
            {
                _sql += "CALL `onclick`.`registervenue`('"+venuename+"', '"+address+"',"+ longitude+","+ latitude+","; 
                _sql += phone+"," + mobile + "," + VendorID + "," + " '"+venuetype+"',";
               
                if (IsDirectoryCreated(venuename))
                {
                    for (int i = 0; i < images.Count; i++)
                    {
                        HttpPostedFileBase file = images[i];
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(FullDir, InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        if (i < 4)
                        {
                            _sql += " '" + file.FileName + "', ";
                        }
                        else {
                            _sql += " '" + file.FileName + "')";
                        }
                        
                    }

                    try
                    {
                        dal.ExecuteData(_sql);
                        msg = "Venue is Registered";
                    }
                    catch (Exception ex) {
                        msg = ex.Message.ToString();
                    }
                }
            }
            
            return Json(msg);
        }

        [NonAction]
        public bool IsDirectoryCreated(string venuename) {
            bool check = false;
            FullDir = srcpath + venuename;
            if (!System.IO.Directory.Exists(FullDir))
            {
                System.IO.Directory.CreateDirectory(FullDir + archive);
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }
        
    }
}