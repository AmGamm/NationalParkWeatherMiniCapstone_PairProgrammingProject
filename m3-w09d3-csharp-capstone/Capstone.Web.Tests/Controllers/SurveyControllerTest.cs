using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capstone.Web.Models;
using Moq;
using Capstone.Web.DALs;


namespace Capstone.Web.Tests.Controllers
{
    [TestClass]
    public class SurveyControllerTest
    {
        [TestMethod]
        public void Survey_HttpGet_ReturnsCorrectView()
        {
            SurveyController Controller = new SurveyController();
            ViewResult result = Controller.Survey() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Survey", result.ViewName);
        }
        //[TestMethod]
        //public void Survey_HttpPost_SavesSurveyAndReturnsRedirect()
        //{
        //    Mock<SurveySqlDAL> mockDal = new Mock<SurveySqlDAL>();
        //    SurveyController controller = new SurveyController(mockDal.Object);
        //    Survey model = new Survey();

        //    RedirectToRouteResult result = controller.Survey(model) as RedirectToRouteResult;

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("SurveyResults", result.RouteValues["action"]);
        //    mockDal.Verify(m => m.SaveSurvey(model));
        //}
    }
}
