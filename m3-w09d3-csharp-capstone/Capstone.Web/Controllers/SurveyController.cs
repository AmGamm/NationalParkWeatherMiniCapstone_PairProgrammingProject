using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DALs;
using System.Configuration;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["NationalParkDB"].ConnectionString;
        // GET: Survey
        public ActionResult Survey()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Survey(Survey survey)
        {
            if (ModelState.IsValid)
            {
                SurveySqlDAL dal = new SurveySqlDAL(connectionString);
                dal.SaveSurvey(survey);
                return RedirectToAction("SurveyResults");
            }
            return View("Survey", survey);
        }

        public ActionResult SurveyResults()
        {
            SurveySqlDAL surveySD = new SurveySqlDAL(connectionString);
            List<Survey> allsurveys = surveySD.GetAllSurveys();
            return View("SurveyResults", allsurveys);
        }
    }
}