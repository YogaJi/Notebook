using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Intergration_test
{
    [TestClass]
    public class JournalTest
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            _webDriver = new EdgeDriver();
        }

        [TestMethod]
        public void If_Journals_Exists()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals");
            Assert.IsTrue(_webDriver.PageSource.Contains("My Journal"));
        }

        [TestMethod]
        public void Test_Open_JournalList()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals");
            Assert.IsTrue(_webDriver.Title.Contains("My Journals"));
        }
        //test journal list table bar items exist
        [TestMethod]
        public void If_JournalList_Table_Items_Exists()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals");
            Assert.IsTrue(_webDriver.Title.Contains("My Journals"));
        }
        //click journal List navigate to the detail page
        [TestMethod]
        public void Test_Click_Journal_List_Nav()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/NoteBookPage?id=2");
            var input = _webDriver.FindElement(By.TagName("a:nth-child(2)"));
            var journalTitle = _webDriver.FindElement(By.PartialLinkText("rtertertrerty5e")).ToString();
            input.Click();
            Assert.IsTrue(_webDriver.PageSource.Contains(journalTitle));
        }

        //create journal in the notebook list page
        [TestMethod]
        public void Test_Click_To_Create_Journal_In_NoteBook_List_Page()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/NoteBookPage?id=2");
            var input = _webDriver.FindElement(By.PartialLinkText("Create new Dairy"));
            input.Click();
            Assert.IsTrue(_webDriver.Url.Contains("NoteBookPage?id=2"));
        }

        //journal CRUD function test
        [TestMethod]
        public void Test_Create_Journal()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals/Create");
            _webDriver.FindElement(By.CssSelector("select#SelectColors :nth-child(2)")).Click();
            _webDriver.FindElement(By.Id("Journal_Date")).SendKeys("002022/06/21 10:52:52");
            _webDriver.FindElement(By.Id("Journal_Title")).SendKeys("NewTitle1");
            _webDriver.FindElement(By.Id("Journal_Content")).SendKeys("NewContent1");
            _webDriver.FindElement(By.ClassName("btn-light")).Click();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals");
            Assert.IsTrue(_webDriver.PageSource.Contains("NewTitle1"));
            Assert.IsTrue(_webDriver.PageSource.Contains("NewContent1"));
            Assert.IsTrue(_webDriver.PageSource.Contains("2022-06-21"));
        }

        //test crete journal from notebook page
        [TestMethod]
        public void Test_Create_From_Notebook_List_Journal()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Notebooks");
            _webDriver.FindElement(By.PartialLinkText("Add New Journal")).Click();  
            Assert.IsTrue(_webDriver.PageSource.Contains("Journals/Create"));
        }

        //test bg color function in create journal
        [TestMethod]
        public void Test_BackGround_Color_Journal()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals/Create");
            _webDriver.FindElement(By.CssSelector("select#SelectColors :nth-child(2)")).Click();
            var bgcolor = _webDriver.FindElement(By.TagName("body")).GetAttribute("style");
            Assert.AreNotEqual("background-color: aliceblue", bgcolor);
        }

        //test if weather icon exist function in create journal
        [TestMethod]
        public void Test_Weather_Icon_Load_Journal()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals/Create");
            var nul = _webDriver.FindElement(By.Id("WeatherImg")).GetAttribute("src");
            _webDriver.FindElement(By.CssSelector("select#SelectWeatherIcon :nth-child(1)")).Click();
            var src = _webDriver.FindElement(By.Id("WeatherImg")).GetAttribute("src");
            Assert.AreNotEqual(nul,src);
        }

        //test if notebook exist in create journal
        [TestMethod]
        public void Test_NoteBook_Load_Journal()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals/Create");
            var note1 = _webDriver.FindElement(By.CssSelector("select#NoteSelected :nth-child(1)")).ToString();
            var note2 = _webDriver.FindElement(By.CssSelector("select#NoteSelected :nth-child(2)")).ToString();
            var note3 = _webDriver.FindElement(By.CssSelector("select#NoteSelected :nth-child(3)")).ToString();
            var note4 = _webDriver.FindElement(By.CssSelector("select#NoteSelected :nth-child(4)")).ToString();

            _webDriver.Navigate().GoToUrl("https://localhost:5001/Notebooks");
            Assert.IsTrue(_webDriver.PageSource.Contains(note1));
            Assert.IsTrue(_webDriver.PageSource.Contains(note2));
            Assert.IsTrue(_webDriver.PageSource.Contains(note3));
            Assert.IsTrue(_webDriver.PageSource.Contains(note4));
        }

        [TestMethod]
        public void Test_Edit_Journal()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals/Edit?id=5");
            _webDriver.FindElement(By.CssSelector("select#Journal_ColorId :nth-child(2)")).Click();

            _webDriver.FindElement(By.Id("Journal_Title")).Clear();
            _webDriver.FindElement(By.Id("Journal_Title")).SendKeys("Changed Title");

            _webDriver.FindElement(By.Id("Journal_Content")).Clear();
            _webDriver.FindElement(By.Id("Journal_Content")).SendKeys("Changed Content");

            _webDriver.FindElement(By.ClassName("btn-primary")).Click();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals");
            Assert.IsTrue(_webDriver.PageSource.Contains("Changed Content"));
            Assert.IsTrue(_webDriver.PageSource.Contains("Changed Title"));
        }

        [TestMethod]
        public void Test_Delete_Journal()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals/Delete?id=5");
            _webDriver.FindElement(By.ClassName("btn-danger")).Click();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Journals/Details?id=5");
            Assert.IsFalse(_webDriver.PageSource.Contains("My Journal"));
        }


        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
