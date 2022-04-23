using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Intergration_test
{
    [TestClass]
    public class ColorTest
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            _webDriver = new EdgeDriver();
        }

        [TestMethod]
        public void If_Color_Exists()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Colors");
            Assert.IsTrue(_webDriver.PageSource.Contains("Colors"));
        }

        //UI color test
        [TestMethod]
        public void Test_Image_Exist_In_Color_List()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Colors");
            var style = _webDriver.FindElement(By.CssSelector("div#BGColorId :nth-child(1)")).GetAttribute("style").ToString(); 
            Assert.IsTrue(_webDriver.PageSource.Contains(style));
        }

        //color CRUD test
        [TestMethod]
        public void Test_Detail_Color()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Colors/Details?id=1");
            var colorinput = _webDriver.FindElement(By.Id("Color_ColorString"));
            Assert.IsNotNull(colorinput);
        }

        [TestMethod]
        public void Test_Edit_Color()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Colors");
            var previousColor = _webDriver.FindElement(By.CssSelector("div#BGColorId :nth-child(2)")).GetAttribute("style");
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Colors/Edit?id=2");
            var input = _webDriver.FindElement(By.Id("Color_ColorString"));
            input.SendKeys("10");
            input.SendKeys("10");
            input.SendKeys("100");
            input.Submit();
            var afterColor = _webDriver.FindElement(By.CssSelector("div#BGColorId :nth-child(2)")).GetAttribute("style");
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Colors");
            Assert.AreNotEqual(previousColor, afterColor);
        }
        [TestMethod]
        public void Test_Create_Color()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Colors");
            var before = _webDriver.FindElement(By.CssSelector("div#BGColorId :last-child")).GetAttribute("style");
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Colors/Create");
            var input = _webDriver.FindElement(By.Id("Color_ColorString"));
            input.SendKeys("180");
            input.SendKeys("174");
            input.SendKeys("188");
            input.Submit();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Colors");
            var after = _webDriver.FindElement(By.CssSelector("div#BGColorId :last-child")).GetAttribute("style");
            Assert.AreNotEqual(before,after);
        }

        [TestMethod]
        public void Test_Delete_Color()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Colors/Delete?id=5");
            _webDriver.FindElement(By.ClassName("btn-danger")).Click();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Colors/Detail?id=5");
            Assert.IsFalse(_webDriver.PageSource.Contains("Colors"));
        }


        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
