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
        public void If_NoteBook_Exists()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/NoteBooks");
            Assert.IsTrue(_webDriver.PageSource.Contains("NoteBook"));
        }


        [TestMethod]
        public void Test_Click_NoteBook_List_Nav()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/NoteBooks");
            var input = _webDriver.FindElement(By.TagName("a :nth-child(4)"));
            input.Click();
            Assert.IsTrue(_webDriver.PageSource.Contains("Edit"));
        }


        //add index page add notebook function test
        [TestMethod]
        public void Test_Create_NoteBook_IndexPage_Exists()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            _webDriver.FindElement(By.PartialLinkText("+ Add New")).Click();
            Assert.IsTrue(_webDriver.Url.Contains("Notebooks/Create"));
        }

        //add index page create notebook and load in index page function test
        [TestMethod]
        public void Test_Create_NoteBook_From_IndexPage_And_Load()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            _webDriver.FindElement(By.PartialLinkText("+ Add New")).Click();
            var input = _webDriver.FindElement(By.Id("Notebook_Name"));
            input.SendKeys("Successful book");
            input.Submit();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            Assert.IsTrue(_webDriver.PageSource.Contains("Successful book"));

            _webDriver.Navigate().GoToUrl("https://localhost:5001/NoteBooks");
            Assert.IsTrue(_webDriver.PageSource.Contains("Successful book"));
        }

        //test greeting page after create notebook
        [TestMethod]
        public void Test_Greeting_Page_After_Create_NoteBook()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/NoteBooks/Create");
            var input = _webDriver.FindElement(By.Id("Notebook_Name"));
            input.SendKeys("bookNo.1");
            input.Submit();
            Assert.IsTrue(_webDriver.PageSource.Contains("Success/success"));
        }

        //basic Notebook CRUD test
        [TestMethod]
        public void Test_Create_NoteBook()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/NoteBooks/Create");
            var input = _webDriver.FindElement(By.Id("Notebook_Name"));
            input.SendKeys("bookNo.2");
            input.Submit();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/NoteBooks");
            Assert.IsTrue(_webDriver.PageSource.Contains("bookNo.2"));
        }

        [TestMethod]
        public void Test_Edit_NoteBook()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/NoteBooks/Edit?id=4");
            var input = _webDriver.FindElement(By.Id("Notebook_Name"));
            input.Clear();
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


        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }

    }
}
