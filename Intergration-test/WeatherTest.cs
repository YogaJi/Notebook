using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Intergration_test
{
    [TestClass]
    class WeatherTest
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            _webDriver = new EdgeDriver();
        }

        [TestMethod]
        public void If_Weather_Exists()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Weather");
            Assert.IsTrue(_webDriver.PageSource.Contains("Weather"));
        }


        //weather CRUD test
        [TestMethod]
        public void Test_Create_Weather()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Weathers/Create");
            var input = _webDriver.FindElement(By.Id("Weather_WeatherPic"));
            input.SendKeys("Blizzard");
            input.Submit();
            Assert.IsTrue(_webDriver.PageSource.Contains("Blizzard"));

        }

        [TestMethod]
        public void Test_Delete_Weather()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Weathers/Delete?id=27");
            _webDriver.FindElement(By.ClassName("btn-danger")).Click();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Weathers");
            Assert.IsFalse(_webDriver.PageSource.Contains("Blizzard"));
        }

        [TestMethod]
        public void Test_Edit_Weather()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Weathers/Edit?id=16");
            var input = _webDriver.FindElement(By.Id("Weather_WeatherPic"));
            input.SendKeys("Hail");
            input.Submit();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Weathers");
            Assert.IsTrue(_webDriver.PageSource.Contains("Hail"));
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
