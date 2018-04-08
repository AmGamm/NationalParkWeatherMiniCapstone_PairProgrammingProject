using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web;
using System.Configuration;
using Capstone.Web.Models;
using Capstone.Web.DALs;


namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["NationalParkDB"].ConnectionString;
        // GET: Home
        public ActionResult Home()
        {

            ParkSqlDAL dal = new ParkSqlDAL(connectionString);
            List<Park> parks = dal.GetParks();
            return View(parks);
        }


        public ActionResult Detail(string id)
        {
            string tempUnit = Session["Temp_Unit"] as string;
                ParkSqlDAL dal = new ParkSqlDAL(connectionString);
                Park park = dal.GetParkDetail(id);
                ViewBag.Park = park;
            if ((tempUnit == null) || (tempUnit == "°F"))
            {
                ViewBag.TempUnit = "°F";
            }
            else
            {
                if(tempUnit == "°C")
                {
                    ViewBag.TempUnit = "°C";
                }
            }
            return View("Detail", park);
        }

        [HttpPost]
        public ActionResult Temp(Park p)
        {
            Session["Temp_Unit"] = p.TempType;
            return RedirectToAction("Detail", "Home", new { id = p.ParkCode });
        }
    }
}