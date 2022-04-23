using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Drawing;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Intergration_test
{
    [TestClass]
    public class IndexPageTest
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            _webDriver = new EdgeDriver();
        }

        [TestMethod]
        public void RealLoad()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            Assert.IsTrue(_webDriver.Title.Contains("NoteBook"));
        }

        [TestMethod]
        public void If_Nav_Exists()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            var nav = _webDriver.FindElement(By.ClassName("navbar"));
            Assert.IsNotNull(nav);
        }

        //UI: add media tests, size
        
        [TestMethod]
        public void Test_Window_Size()
        {
            _webDriver.Manage().Window.Size = new Size(1024, 768);
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
        }


        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
