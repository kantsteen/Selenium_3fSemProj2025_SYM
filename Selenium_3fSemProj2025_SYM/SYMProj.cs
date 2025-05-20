using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Selenium_3fSemProj2025_SYM
{
    [TestClass]
    public sealed class SYMProj
    {

        //private static readonly string DriverDirector = "C:\\webdrivers";
        private static readonly string DriverDirector = "C:\\WebDriver";
        private static IWebDriver _driver;


        [ClassInitialize]
        public static void setup(TestContext context)
        {
            //_driver = new FirefoxDriver(DriverDirector);
            _driver = new ChromeDriver(DriverDirector);
        }

        //[ClassCleanup]
        //public static void TearDown()
        //{
        //    _driver.Dispose();
        //}

        [TestInitialize]
        public void InitializeTest()
        {
            //string overview = "C:\\Datamatiker_3_sem\\3fSemesterProjekt2025\\oversigt.html";
            string overview = "C:\\Users\\jonas\\3SemProjFront\\3fSemesterProjektHjemmeside\\oversigt.html";
            _driver.Navigate().GoToUrl(overview);

            Assert.AreEqual("3fSemesterProjekt", _driver.Title);
             
        }

        [TestMethod]
        public void TestMethod1()
        {
            IWebElement mainPage = _driver.FindElement(By.Id("main_page_button"));
            mainPage.Click();
        }
    }
}
