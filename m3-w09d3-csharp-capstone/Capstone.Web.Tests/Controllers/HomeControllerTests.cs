using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void HomeController_Home_ReturnHomeView()
        {
            ////Arrange
            HomeController controller = new HomeController();


            ////Act
            ViewResult result = controller.Home() as ViewResult;
            ViewResult result2 = controller.Detail("CVNP") as ViewResult;


            ////Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home", result.ViewName);
            Assert.IsNotNull(result2);
            Assert.AreEqual("Detail", result2.ViewName);
        }
        [TestMethod()]
        public void HomeController_Detauk_ReturnDetailView()
        {
            ////Arrange
            HomeController controller = new HomeController();


            ////Act
            ViewResult result = controller.Detail("CVNP") as ViewResult;


            ////Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Detail", result.ViewName);
        }
    }

}