using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Diagnostics;
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
        public void Test_Window_Size_xm()
        {
            //xm size
            _webDriver.Manage().Window.Size = new Size(573, 838);
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            var styles = _webDriver.FindElement(By.ClassName("notebooks")).GetAttribute("style").ToString();
            Debug.WriteLine(styles);
            
            Assert.IsTrue(styles.Contains("ghostwhite"));
        }

        [TestMethod]
        public void Test_Window_Size_x()
        {
            //x size
            _webDriver.Manage().Window.Size = new Size(580, 708);
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            var styles = _webDriver.FindElement(By.ClassName("notebooks")).GetAttribute("style").ToString();
            Debug.WriteLine(styles);

            Assert.IsTrue(styles.Contains("yellowgreen"));
        }

        [TestMethod]
        public void Test_Window_Size_m()
        {
            //m size
            _webDriver.Manage().Window.Size = new Size(1000, 708);
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            var styles = _webDriver.FindElement(By.ClassName("notebooks")).GetAttribute("style").ToString();
            Debug.WriteLine(styles);

            Assert.IsTrue(styles.Contains("lightpink"));
        }

        [TestMethod]
        public void Test_Window_Size_l()
        {
            //l size
            _webDriver.Manage().Window.Size = new Size(1200, 708);
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            var styles = _webDriver.FindElement(By.ClassName("notebooks")).GetAttribute("style").ToString();
            Debug.WriteLine(styles);

            Assert.IsTrue(styles.Contains("mediumpurple"));
        }

        [TestMethod]
        public void Test_Window_Size_xl()
        {
            //xl size
            _webDriver.Manage().Window.Size = new Size(1400, 708);
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            var styles = _webDriver.FindElement(By.ClassName("notebooks")).GetAttribute("style").ToString();
            Debug.WriteLine(styles);

            Assert.IsTrue(styles.Contains("darkslategrey"));
        }

        [TestMethod]
        public void Test_Window_Size_xxl()
        {
            //xxl size
            _webDriver.Manage().Window.Size = new Size(2000, 1200);
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            var styles = _webDriver.FindElement(By.ClassName("notebooks")).GetAttribute("style").ToString();
            Debug.WriteLine(styles);

            Assert.IsTrue(styles.Contains("darkslategrey"));
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
