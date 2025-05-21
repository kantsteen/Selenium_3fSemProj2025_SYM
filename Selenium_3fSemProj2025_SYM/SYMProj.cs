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

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

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
                    var result = js.ExecuteScript("return window.vueApp && window.vueApp.filteredPeriod && window.vueApp.filteredPeriod.length > 0;");
                    return result is bool b && b;
                }
                catch
                {
                    return false;
                }
            });

            // Finally, check the length
            var gpsDataLength = (long)js.ExecuteScript("return window.vueApp.filteredPeriod.length;");
            Assert.IsTrue(gpsDataLength == 0, "gpsData should contain zero data points for the past day.");
        }

        [TestMethod]
        public void ShowPastWeekTest()
        {
            Thread.Sleep(500);

            IWebElement overviewButton = _driver.FindElement(By.Id("earlier_incidents_button"));
            overviewButton.Click();


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
                    var result = js.ExecuteScript("return window.vueApp && window.vueApp.filteredPeriod && window.vueApp.filteredPeriod.length > 0;");
                    return result is bool b && b;
                }
                catch
                {
                    return false;
                }
            });

            // Finally, check the length
            var gpsDataLength = (long)js.ExecuteScript("return window.vueApp.filteredPeriod.length;");
            Assert.IsTrue(gpsDataLength == 25, "gpsData should contain at least one point for the past week.");
        }

        [TestMethod]
        public void ShowPastMonthTest()
        {
            Thread.Sleep(500);

            IWebElement overviewButton = _driver.FindElement(By.Id("earlier_incidents_button"));
            overviewButton.Click();

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
                    var result = js.ExecuteScript("return window.vueApp && window.vueApp.filteredPeriod && window.vueApp.filteredPeriod.length > 0;");
                    return result is bool b && b;
                }
                catch
                {
                    return false;
                }
            });

            // Finally, check the length
            var gpsDataLength = (long)js.ExecuteScript("return window.vueApp.filteredPeriod.length;");
            Assert.IsTrue(gpsDataLength == 45, "gpsData should contain at least one point for the past month.");
        }

        [TestMethod]
        public void ShowPastYearTest()
        {
            Thread.Sleep(500);

            IWebElement overviewButton = _driver.FindElement(By.Id("earlier_incidents_button"));
            overviewButton.Click();

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
                    var result = js.ExecuteScript("return window.vueApp && window.vueApp.filteredPeriod && window.vueApp.filteredPeriod.length > 0;");
                    return result is bool b && b;
                }
                catch
                {
                    return false;
                }
            });

            // Finally, check the length
            var gpsDataLength = (long)js.ExecuteScript("return window.vueApp.filteredPeriod.length;");
            Assert.IsTrue(gpsDataLength == 45, "gpsData should contain at least one point for the past year.");
        }

        [TestMethod]
        public void FromToDateTest()
        {
            // First navigate to the overview page since the test starts on index.html
            IWebElement overviewButton = _driver.FindElement(By.Id("earlier_incidents_button"));
            overviewButton.Click();

            // Wait for page to load
            Thread.Sleep(1000);

            // Clear the input fields first (important for reliable input)
            IWebElement fromDateInput = _driver.FindElement(By.Id("from_date_input"));
            fromDateInput.Clear();
            fromDateInput.SendKeys("18052025950"); // Consider using proper date format

            Thread.Sleep(500);

            IWebElement toDateInput = _driver.FindElement(By.Id("to_date_input"));
            toDateInput.Clear();
            toDateInput.SendKeys("200520251350");

            Thread.Sleep(500);

            IWebElement searchButton = _driver.FindElement(By.Id("search_button"));
            searchButton.Click();

            // Now wait until Vue has updated the filteredGpsData after filtering
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15)); // Extended timeout

            wait.Until(driver =>
            {
                try
                {
                    // Check both the existence of filteredGpsData AND that it has elements
                    var result = js.ExecuteScript("return window.vueApp && window.vueApp.filteredGpsData && window.vueApp.filteredGpsData.length > 0;");
                    return result is bool b && b;
                }
                catch
                {
                    return false;
                }
            });

            // Finally, check the length
            var filteredDataLength = (long)js.ExecuteScript("return window.vueApp.filteredGpsData.length;");
            Assert.IsTrue(filteredDataLength == 25, "filteredGpsData should contain at least one point for the selected date range.");
        }

        //[TestMethod]
        //public void FromToDateTest()
        //{
        //    Thread.Sleep(500);

        //    IWebElement fromDateInput = _driver.FindElement(By.Id("from_date_input"));
        //    //fromDateInput.Click();

        //    fromDateInput.SendKeys("18052025950");

        //    Thread.Sleep(1000);

        //    IWebElement toDateInput = _driver.FindElement(By.Id("to_date_input"));
        //    //toDateInput.Click();

        //    toDateInput.SendKeys("200520251350");

        //    Thread.Sleep(1000);

        //    IWebElement searchButton = _driver.FindElement(By.Id("search_button"));
        //    searchButton.Click();

        //    // Now wait until Vue has updated the gpsData after filtering
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        //    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

        //    wait.Until(driver =>
        //    {
        //        try
        //        {
        //            var result = js.ExecuteScript("return window.vueApp && window.vueApp.filteredGpsData && window.vueApp.filteredGpsData.length > 0;");
        //            return result is bool b && b;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    });

        //    // Finally, check the length
        //    var gpsDataLength = (long)js.ExecuteScript("return window.vueApp.filteredGpsData.length;");
        //    Assert.IsTrue(gpsDataLength > 0, "gpsData should contain at least one point for the past day.");
        //}
    }
}
