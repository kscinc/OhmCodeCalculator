using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OhmCodeCalculator;
using OhmCodeCalculator.Controllers;
using ColorCodeCalculator;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace OhmCodeCalculator.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ZeroBandResistorTest()
        {
            Exception exceptionResult = null;

            try
            {    // Arrange 
                IOhmValueCalculator ohmValueCalculator = new ResistanceCalculator();

                // Act
                ohmValueCalculator.CalculateOhmValue(null, null, null, null);
            }
            catch (Exception exception)
            {
                exceptionResult = exception;
            }

            // Assert
            Assert.IsNotNull(exceptionResult);
            Assert.IsInstanceOfType(exceptionResult, typeof(ArgumentException));
        }


        [TestMethod]
        public void TestResistor1()
        {
            //Arrange
            IOhmValueCalculator ohmValueCalculator = new ResistanceCalculator();

            //Act
            ColorCodeResult result = ohmValueCalculator.CalculateOhmValue("yellow", "red", "red", "gold");

            //Assert
            Assert.AreEqual("4410", result.MaximumResistance);
        }

        [TestMethod]
        public void TestResistor2()
        {
            //Arrange
            IOhmValueCalculator ohmValueCalculator = new ResistanceCalculator();

            //Act
            ColorCodeResult result = ohmValueCalculator.CalculateOhmValue("white", "blue", "pink", "green");

            //Assert
            Assert.AreEqual("0.09648", result.MaximumResistance);
        }

        [TestMethod]
        public void TestResistor3()
        {
            //Arrange
            IOhmValueCalculator ohmValueCalculator = new ResistanceCalculator();

            //Act
            ColorCodeResult result = ohmValueCalculator.CalculateOhmValue("green", "black", "pink", "blue");

            //Assert
            Assert.AreEqual("0.050125", result.MaximumResistance);
        }

        [TestMethod]
        public void TestVeryLargeResistance()
        {
            //Arrange
            IOhmValueCalculator ohmValueCalculator = new ResistanceCalculator();

            //Act
            ColorCodeResult result = ohmValueCalculator.CalculateOhmValue("white", "white", "white", "brown");

            //Assert
            Assert.AreEqual("99,990M", result.MaximumResistance);
        }

    }
}
