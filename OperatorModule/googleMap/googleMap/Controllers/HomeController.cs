using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using googleMap.Models;
using googleMap.Models.Database;

namespace googleMap.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.QueryString.Count > 0)
            {
                ViewData["lat"] = Request.QueryString["lat"].ToString();
                ViewData["long"] = Request.QueryString["long"].ToString();
                ViewData["PostID"] = Request.QueryString["PostDetail"].ToString();
            }
            else
            {
                //Mark all Post location
                return RedirectToAction("ShowAllPost");
            }

            return View();
        }

        public ActionResult AddPost()
        {
            if (Request.Params.ToString().IndexOf("Submit") > 0)
            {
                string UniqueID = Request.QueryString["ClusterNo"].ToString();
                string Lat = Request.QueryString["LatTxt"].ToString();
                string Lng = Request.QueryString["LngTxt"].ToString();
                string PostName = Request.QueryString["PostName"].ToString();
                string SerialNo = Request.QueryString["SerialNo"].ToString();
                //Insert to Database 
                //Check if cluster has tbl_Post 
                tbl_Cluster cluster = Service.HasTbl_Post(UniqueID);
                if (cluster != null)
                {
                    if (PostName.Contains(","))
                        PostName = PostName.Replace(",", "");
                    //Insert tbl_Post  
                    Service.Insert_Post(cluster.ID, PostName, SerialNo);
                    //Insert tbl_Map
                    Service.Insert_Map(Lat, Lng, SerialNo);
                }
            }
            if (Request.QueryString.AllKeys.Contains("Cluster"))
            {
                ViewData["Cluster"] = Request.QueryString["Cluster"].ToString();
            }
            return View();
        }

        public ActionResult ShowAllPost()
        {
            string Location = Service.GetAllStringLocation();
            if (!string.IsNullOrEmpty(Location))
            {
                int counter = 0;
                string[] arrayLocation = Location.Split(';');
                if (arrayLocation.Length > 0)
	            {
                    foreach (string item in arrayLocation)
                    {
                        if (item != "")
                        {
                            string[] index = item.Split(',');
                            ViewData["Details" + counter.ToString()] = index[0];
                            ViewData["Lat" + counter.ToString()] = index[1];
                            ViewData["Long" + counter.ToString()] = index[2];
                            counter++;
                            ViewData["counter"] = counter; 
                        }
                    }
                    ViewData["locations"] = Location;  
	            }
                else
                    ViewData["locations"] = "";
            }
            return View();
        }

        public JsonResult GetLocationByLatLong(string Lat, string Long)
        {
            if (!string.IsNullOrEmpty(Lat) && !string.IsNullOrEmpty(Long))
            {
                string location = Service.GetLocation(Lat, Long);
                if (!string.IsNullOrEmpty(location))
	            {
		            return Json(new { Result = true, Location = location }, JsonRequestBehavior.AllowGet); 
	            }
            }
            return Json(new { Result = false }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSerialNumber()
        {
            //Generate Post Serial Number
            string serial = Service.GenerateSerialNumber();
            if (!string.IsNullOrEmpty(serial))
                return Json(new { Result = true, Serial = serial }, JsonRequestBehavior.AllowGet);
            return Json(new { Result = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
