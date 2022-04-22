using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Intergration_test
{
    [TestClass]
    public class NoteBookTest
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

        [TestMethod]
        public void If_NoteBook_Exists()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/NoteBooks");
            Assert.IsTrue(_webDriver.PageSource.Contains("NoteBook"));
        }
        [TestMethod]
        public void If_Journals_Exists()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals");
            Assert.IsTrue(_webDriver.PageSource.Contains("My Journal"));
        }

        [TestMethod]
        public void If_Mood_Exists()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods");
            Assert.IsTrue(_webDriver.PageSource.Contains("Moods"));
        }

        [TestMethod]
        public void If_Weather_Exists()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Weather");
            Assert.IsTrue(_webDriver.PageSource.Contains("Weather"));
        }

        [TestMethod]
        public void Test_Edit_NoteBook()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/NoteBooks/Edit?id=4");
            var input = _webDriver.FindElement(By.Id("Notebook_Name"));
            input.SendKeys("NewNote1");
            input.Submit();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/NoteBooks");
            Assert.IsTrue(_webDriver.PageSource.Contains("NewNote1"));
        }

        [TestMethod]
        public void Test_Delete_NoteBook()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/NoteBooks/Delete?id=4");
            _webDriver.FindElement(By.ClassName("btn-danger")).Click();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/NoteBooks");
            Assert.IsFalse(_webDriver.PageSource.Contains("NewNote1"));
        }

        [TestMethod]
        public void Test_Open_JournalList_NoteBook()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals?id=26");
            Assert.IsTrue(_webDriver.Title.Contains("My Journal"));
        }

        [TestMethod]
        public void Test_Create_Mood()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods/Create");
            var input = _webDriver.FindElement(By.Id("Mood_MoodPic"));
            input.SendKeys("Angry");
            input.Submit();
            Assert.IsTrue(_webDriver.PageSource.Contains("Angry"));
        }

        [TestMethod]
        public void Test_Delete_Mood()
        {

            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods/Delete?id=29");
            _webDriver.FindElement(By.ClassName("btn-danger")).Click();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods");
            Assert.IsFalse(_webDriver.PageSource.Contains("Good"));
        }

        [TestMethod]
        public void Test_Edit_Mood()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods/Edit?id=3");
            var input = _webDriver.FindElement(By.Id("Mood_MoodPic"));
            input.SendKeys("BetterMood");
            input.Submit();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Moods");
            Assert.IsTrue(_webDriver.PageSource.Contains("BetterMood"));
        }

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

        [TestMethod]
        public void Test_Create_Journal()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals/Create");
            _webDriver.FindElement(By.Id("Journal_BackgroundColor")).SendKeys("Pink");
            _webDriver.FindElement(By.Id("Journal_Date")).SendKeys("002022/06/21 10:52:52");
            _webDriver.FindElement(By.Id("Journal_Title")).SendKeys("NewTitle1");
            _webDriver.FindElement(By.Id("Journal_Content")).SendKeys("NewContent1");
            _webDriver.FindElement(By.ClassName("btn-primary")).Click();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals");
            Assert.IsTrue(_webDriver.PageSource.Contains("NewTitle1"));
            Assert.IsTrue(_webDriver.PageSource.Contains("NewContent1"));
            Assert.IsTrue(_webDriver.PageSource.Contains("2022-06-21"));
        }

        [TestMethod]
        public void Test_Edit_Journal()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals/Edit?id=18");
            _webDriver.FindElement(By.Id("Journal_BackgroundColor")).SendKeys("Green");
            _webDriver.FindElement(By.Id("Journal_Title")).SendKeys("Changed Title");
            _webDriver.FindElement(By.Id("Journal_Content")).SendKeys("Changed Content");
            _webDriver.FindElement(By.ClassName("btn-primary")).Click();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals");
            Assert.IsTrue(_webDriver.PageSource.Contains("Changed Content"));
            Assert.IsTrue(_webDriver.PageSource.Contains("Changed Title"));
        }

        [TestMethod]
        public void Test_Delete_Journal()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals/Delete?id=19");
            _webDriver.FindElement(By.ClassName("btn-danger")).Click();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals/Details?id=19");
            Assert.IsFalse(_webDriver.PageSource.Contains("My Journal"));
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }

    }
}
