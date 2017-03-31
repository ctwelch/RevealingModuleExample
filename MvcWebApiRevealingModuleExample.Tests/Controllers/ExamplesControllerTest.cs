using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcWebApiRevealingModuleExample;
using MvcWebApiRevealingModuleExample.Controllers;
using MvcWebApiRevealingModuleExample.Models;

namespace MvcWebApiRevealingModuleExample.Tests.Controllers
{
    [TestClass]
    public class ExamplesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ExamplesController controller = new ExamplesController();

            // Act
            IEnumerable<Example> result = controller.GetAllExamples();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ExamplesController controller = new ExamplesController();

            // Act
            Example result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ExamplesController controller = new ExamplesController();

            // Act
            controller.PostExample(new Example());

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ExamplesController controller = new ExamplesController();

            // Act
            controller.PutExample(5, new Example());

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ExamplesController controller = new ExamplesController();

            // Act
            controller.DeleteExample(5);

            // Assert
        }
    }
}
