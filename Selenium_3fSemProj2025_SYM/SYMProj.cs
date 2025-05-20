using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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
            //string index = "C:\\Users\\jonas\\3SemProjFront\\3fSemesterProjektHjemmeside\\index.html";
            _driver.Navigate().GoToUrl(index);

            Assert.AreEqual("3fSemesterProjekt", _driver.Title);
        }


        [TestMethod]
        public void ShowPastDayTest() {

            IWebElement overviewButton = _driver.FindElement(By.Id("earlier_incidents_button"));
            overviewButton.Click();

            // Click the button that opens the period dropdown
            IWebElement periodButton = _driver.FindElement(By.Id("choose_period_button"));
            periodButton.Click();

            // Click the "Past Day" option
            IWebElement pastDayButton = _driver.FindElement(By.Id("past_day_option"));
            pastDayButton.Click();

            // Now wait until Vue has updated the gpsData after filtering
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(driver =>
            {
                try
                {
                    var result = js.ExecuteScript("return window.vueApp && window.vueApp.gpsData && window.vueApp.gpsData.length > 0;");
                    return result is bool b && b;
                }
                catch
                {
                    return false;
                }
            });

            // Finally, check the length
            var gpsDataLength = (long)js.ExecuteScript("return window.vueApp.gpsData.length;");
            Assert.IsTrue(gpsDataLength > 0, "gpsData should contain at least one point for the past day.");
        }

        [TestMethod]
        public void ShowPastWeekTest()
        {
            Thread.Sleep(500);
            // Click the button that opens the period dropdown
            IWebElement periodButton = _driver.FindElement(By.Id("choose_period_button"));
            periodButton.Click();

            // Click the "Past Day" option
            IWebElement pastWeekButton = _driver.FindElement(By.Id("past_week_option"));
            pastWeekButton.Click();

            // Now wait until Vue has updated the gpsData after filtering
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(driver =>
            {
                try
                {
                    var result = js.ExecuteScript("return window.vueApp && window.vueApp.gpsData && window.vueApp.gpsData.length > 0;");
                    return result is bool b && b;
                }
                catch
                {
                    return false;
                }
            });

            // Finally, check the length
            var gpsDataLength = (long)js.ExecuteScript("return window.vueApp.gpsData.length;");
            Assert.IsTrue(gpsDataLength > 0, "gpsData should contain at least one point for the past day.");
        }

        [TestMethod]
        public void ShowPastMonthTest()
        {
            Thread.Sleep(500);

            // Click the button that opens the period dropdown
            IWebElement periodButton = _driver.FindElement(By.Id("choose_period_button"));
            periodButton.Click();

            // Click the "Past Day" option
            IWebElement pastMonthButton = _driver.FindElement(By.Id("past_month_option"));
            pastMonthButton.Click();

            // Now wait until Vue has updated the gpsData after filtering
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(driver =>
            {
                try
                {
                    var result = js.ExecuteScript("return window.vueApp && window.vueApp.gpsData && window.vueApp.gpsData.length > 0;");
                    return result is bool b && b;
                }
                catch
                {
                    return false;
                }
            });

            // Finally, check the length
            var gpsDataLength = (long)js.ExecuteScript("return window.vueApp.gpsData.length;");
            Assert.IsTrue(gpsDataLength > 0, "gpsData should contain at least one point for the past day.");
        }

        [TestMethod]
        public void ShowPastYearTest()
        {
            Thread.Sleep(500);

            // Click the button that opens the period dropdown
            IWebElement periodButton = _driver.FindElement(By.Id("choose_period_button"));
            periodButton.Click();

            // Click the "Past Day" option
            IWebElement pastYearButton = _driver.FindElement(By.Id("past_year_option"));
            pastYearButton.Click();

            // Now wait until Vue has updated the gpsData after filtering
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(driver =>
            {
                try
                {
                    var result = js.ExecuteScript("return window.vueApp && window.vueApp.gpsData && window.vueApp.gpsData.length > 0;");
                    return result is bool b && b;
                }
                catch
                {
                    return false;
                }
            });

            // Finally, check the length
            var gpsDataLength = (long)js.ExecuteScript("return window.vueApp.gpsData.length;");
            Assert.IsTrue(gpsDataLength > 0, "gpsData should contain at least one point for the past day.");
        }

        [TestMethod]
        public void FromToDateTest()
        {
            Thread.Sleep(500);

            IWebElement fromDateInput = _driver.FindElement(By.Id("from_date_input"));
            //fromDateInput.Click();

            fromDateInput.SendKeys("18052025950");

            Thread.Sleep(1000);

            IWebElement toDateInput = _driver.FindElement(By.Id("to_date_input"));
            //toDateInput.Click();

            toDateInput.SendKeys("200520251350");

            Thread.Sleep(1000);

            IWebElement searchButton = _driver.FindElement(By.Id("search_button"));
            searchButton.Click();

            // Now wait until Vue has updated the gpsData after filtering
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(driver =>
            {
                try
                {
                    var result = js.ExecuteScript("return window.vueApp && window.vueApp.gpsData && window.vueApp.gpsData.length > 0;");
                    return result is bool b && b;
                }
                catch
                {
                    return false;
                }
            });

            // Finally, check the length
            var gpsDataLength = (long)js.ExecuteScript("return window.vueApp.gpsData.length;");
            Assert.IsTrue(gpsDataLength == 44, "gpsData should contain at least one point for the past day.");
        }
    }
}
