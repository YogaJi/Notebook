using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Intergration_test
{
    [TestClass]
    class MoodTest
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            _webDriver = new EdgeDriver();
        }

        [TestMethod]
        public void If_Mood_Exists()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods");
            Assert.IsTrue(_webDriver.PageSource.Contains("Moods"));
        }

        //mood CRUD test
        [TestMethod]
        public void Test_Create_Mood()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods/Create");
            var input = _webDriver.FindElement(By.Id("Mood_MoodPic"));
            input.SendKeys("😮");
            input.Submit();
            Assert.IsTrue(_webDriver.PageSource.Contains("😮"));
        }
        
        [TestMethod]
        public void Test_Detail_Mood()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods");
            _webDriver.FindElement(By.PartialLinkText("Detail :first-child")).Click();
            var input = _webDriver.FindElement(By.Id("Mood_MoodPic"));
            Assert.AreEqual(input, "😅");
        }

        [TestMethod]
        public void Test_Delete_Mood()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods/Delete?id=2");
            _webDriver.FindElement(By.ClassName("btn-danger")).Click();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods");
            Assert.IsFalse(_webDriver.PageSource.Contains("🤨"));
        }

        [TestMethod]
        public void Test_Edit_Mood()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods/Edit?id=2");
            var input = _webDriver.FindElement(By.Id("Mood_MoodPic"));
            input.SendKeys("🥴");
            input.Submit();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods");
            Assert.IsTrue(_webDriver.PageSource.Contains("🥴"));
        }


        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
