using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Selenium_3fSemProj2025_SYM
{
    [TestClass]
    public sealed class SYMProj
    {

        private static readonly string DriverDirector = "C:\\webdrivers";
        //private static readonly string DriverDirector = "C:\\WebDriver";
        private static IWebDriver _driver;


        [ClassInitialize]
        public static void setup(TestContext context)
        {
            _driver = new FirefoxDriver(DriverDirector);
            //_driver = new ChromeDriver(DriverDirector);
        }

        //[ClassCleanup]
        //public static void TearDown()
        //{
        //    _driver.Dispose();
        //}

        [TestInitialize]
        public void InitializeTest()
        {
            string index = "C:\\Datamatiker_3_sem\\3fSemesterProjekt2025\\index.html";
            //string overview = "C:\\Users\\jonas\\3SemProjFront\\3fSemesterProjektHjemmeside\\oversigt.html";
            _driver.Navigate().GoToUrl(index);

            Assert.AreEqual("3fSemesterProjekt", _driver.Title);

            IWebElement overviewButton = _driver.FindElement(By.Id("earlier_incidents_button"));
            overviewButton.Click();
        }


        [TestMethod]
        public void ShowPastDayTest()
        {
            IWebElement periodButton = _driver.FindElement(By.Id("choose_period_button"));
            periodButton.Click();

            IWebElement pastDayButton = _driver.FindElement(By.Id("past_day_option"));
            pastDayButton.Click();
        }
    }
}
