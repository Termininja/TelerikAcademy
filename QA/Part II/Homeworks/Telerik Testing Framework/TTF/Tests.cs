namespace TTF
{
    using System.Collections.Generic;
    using System.Linq;

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.TestTemplates;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Tests : BaseTest
    {

        #region [Setup / TearDown]

        private TestContext testContextInstance = null;
        /// <summary>
        ///Gets or sets the VS test context which provides
        ///information about and functionality for the
        ///current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
        }

        // Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            #region WebAii Initialization

            // Initializes WebAii manager to be used by the test case.
            // If a WebAii configuration section exists, settings will be
            // loaded from it. Otherwise, will create a default settings
            // object with system defaults.
            //
            // Note: We are passing in a delegate to the VisualStudio
            // testContext.WriteLine() method in addition to the Visual Studio
            // TestLogs directory as our log location. This way any logging
            // done from WebAii (i.e. Manager.Log.WriteLine()) is
            // automatically logged to the VisualStudio test log and
            // the WebAii log file is placed in the same location as VS logs.
            //
            // If you do not care about unifying the log, then you can simply
            // initialize the test by calling Initialize() with no parameters;
            // that will cause the log location to be picked up from the config
            // file if it exists or will use the default system settings (C:\WebAiiLog\)
            // You can also use Initialize(LogLocation) to set a specific log
            // location for this test.

            // Pass in 'true' to recycle the browser between test methods
            Initialize(false, this.TestContext.TestLogsDir, new TestContextWriteLine(this.TestContext.WriteLine));

            // If you need to override any other settings coming from the
            // config section you can comment the 'Initialize' line above and instead
            // use the following:

            /*

            // This will get a new Settings object. If a configuration
            // section exists, then settings from that section will be
            // loaded

            Settings settings = GetSettings();

            // Override the settings you want. For example:
            settings.Web.DefaultBrowser = BrowserType.FireFox;

            // Now call Initialize again with your updated settings object
            Initialize(settings, new TestContextWriteLine(this.TestContext.WriteLine));

            */

            // Set the current test method. This is needed for WebAii to discover
            // its custom TestAttributes set on methods and classes.
            // This method should always exist in [TestInitialize()] method.
            SetTestMethod(this, (string)TestContext.Properties["TestName"]);

            #endregion

            //
            // Place any additional initialization here
            //
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            //
            // Place any additional cleanup here
            //

            #region WebAii CleanUp

            // Shuts down WebAii manager and closes all browsers currently running
            // after each test. This call is ignored if recycleBrowser is set
            this.CleanUp();

            #endregion
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            // This will shut down all browsers if
            // recycleBrowser is turned on. Else
            // will do nothing.
            ShutDown();
        }

        #endregion

        #region Task 1: Test Search in TelerikAcademy

        [TestMethod]
        public void TelerikAcademySearchWPF()
        {
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://telerikacademy.com");
            Find.ById<HtmlInputText>("SearchTerm").Text = "wpf";
            Find.ById<HtmlInputSubmit>("SearchButton").Click();

            var coursesList = Find.AllByAttributes<HtmlDiv>("class=SearchResultsCategory")
                .Where(course => course.InnerText.Contains("Курсове")).FirstOrDefault()
                .Find.ByAttributes<HtmlUnorderedList>("class=SearchMetroList");

            var tracksList = Find.AllByAttributes<HtmlDiv>("class=SearchResultsCategory")
                .Where(track => track.InnerText.Contains("Тракове")).FirstOrDefault()
                .Find.ByAttributes<HtmlUnorderedList>("class=SearchMetroList");

            Assert.AreEqual(2, coursesList.Items.Count(), "Count of courses is wrong!");
            Assert.AreEqual(1, tracksList.Items.Count(), "Count of tracks is wrong!");
        }

        [TestMethod]
        public void TelerikAcademySearchQuality()
        {
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://telerikacademy.com");
            Find.ById<HtmlInputText>("SearchTerm").Text = "quality";
            Find.ById<HtmlInputSubmit>("SearchButton").Click();

            var usersList = Find.AllByAttributes<HtmlDiv>("class=SearchResultsCategory")
                .Where(user => user.InnerText.Contains("Потребители")).FirstOrDefault()
                .Find.ByAttributes<HtmlUnorderedList>("class=SearchMetroList");

            var coursesList = Find.AllByAttributes<HtmlDiv>("class=SearchResultsCategory")
                .Where(course => course.InnerText.Contains("Курсове")).FirstOrDefault()
                .Find.ByAttributes<HtmlUnorderedList>("class=SearchMetroList");

            var tracksList = Find.AllByAttributes<HtmlDiv>("class=SearchResultsCategory")
                .Where(track => track.InnerText.Contains("Тракове")).FirstOrDefault()
                .Find.ByAttributes<HtmlUnorderedList>("class=SearchMetroList");

            Assert.AreEqual(1, usersList.Items.Count(), "Count of users is wrong!");
            Assert.AreEqual(5, coursesList.Items.Count(), "Count of courses is wrong!");
            Assert.AreEqual(1, tracksList.Items.Count(), "Count of tracks is wrong!");
        }

        [TestMethod]
        public void TelerikAcademySearchWebaiii()
        {
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://telerikacademy.com");
            Find.ById<HtmlInputText>("SearchTerm").Text = "Webaiii";
            Find.ById<HtmlInputSubmit>("SearchButton").Click();

            Assert.IsTrue(Find.ByXPath("/html/body/div/div/section/h1").InnerText.Contains("Вашето търсене не върна резултат"));
        }

        #endregion

        #region Task 2: Test calculator

        [TestMethod]
        public void CalculatorDigitsTest()
        {
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html");

            for (int i = 3; i <= 6; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[" + i + "]/td[" + j + "]/input").Click();
                    if (i == 6) break;
                }
            }

            var result = Find.ById<HtmlInputText>("calc_result").Text;
            Assert.AreEqual("7894561230", result);
        }

        [TestMethod]
        public void CalculatorBackspaceTest()
        {
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html");

            for (int i = 3; i <= 6; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[" + i + "]/td[" + j + "]/input").Click();
                    if (i == 6) break;
                }
            }

            for (int b = 0; b < 5; b++)
            {
                Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[2]/td[2]/input").Click();
            }

            var result = Find.ById<HtmlInputText>("calc_result").Text;
            Assert.AreEqual("78945", result);
        }

        [TestMethod]
        public void CalculatorClearTest()
        {
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html");

            for (int i = 3; i <= 6; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[" + i + "]/td[" + j + "]/input").Click();
                    if (i == 6) break;
                }
            }

            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[2]/td[1]/input").Click();

            var result = Find.ById<HtmlInputText>("calc_result").Text;
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void CalculatorCommaTest()
        {
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html");
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[4]/td[2]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[6]/td[3]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[4]/td[2]/input").Click();

            var result = Find.ById<HtmlInputText>("calc_result").Text;
            Assert.AreEqual("5.5", result);
        }

        [TestMethod]
        public void CalculatorSignTest()
        {
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html");
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[4]/td[2]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[6]/td[2]/input").Click();
            var negativeResult = Find.ById<HtmlInputText>("calc_result").Text;

            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[6]/td[2]/input").Click();
            var positiveResult = Find.ById<HtmlInputText>("calc_result").Text;

            Assert.AreEqual("-5", negativeResult);
            Assert.AreEqual("5", positiveResult);
        }

        [TestMethod]
        public void CalculatorAdditionTest()
        {
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html");
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[4]/td[2]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[2]/td[4]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[5]/td[3]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[6]/td[4]/input").Click();

            var result = Find.ById<HtmlInputText>("calc_result").Text;

            Assert.AreEqual("8", result);   //5+3=8
        }

        [TestMethod]
        public void CalculatorSubtractionTest()
        {
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html");
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[4]/td[2]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[3]/td[4]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[5]/td[3]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[6]/td[4]/input").Click();

            var result = Find.ById<HtmlInputText>("calc_result").Text;

            Assert.AreEqual("2", result);   //5-3=2
        }

        [TestMethod]
        public void CalculatorMultiplicationTest()
        {
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html");
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[4]/td[2]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[4]/td[4]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[5]/td[3]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[6]/td[4]/input").Click();

            var result = Find.ById<HtmlInputText>("calc_result").Text;

            Assert.AreEqual("15", result);  //5*3=15
        }

        [TestMethod]
        public void CalculatorDivisionTest()
        {
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html");
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[3]/td[2]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[5]/td[4]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[5]/td[2]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[6]/td[4]/input").Click();

            var result = Find.ById<HtmlInputText>("calc_result").Text;

            Assert.AreEqual("4", result);   //8/2=4

            //Bug found: javascript:f_calc('calc',''); has to be: javascript:f_calc('calc','÷')
        }

        [TestMethod]
        public void CalculatorPercentTest()
        {
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://www.webestools.com/ftp/ybouane/scripts_tutorials/javascript/calculator/calculator.html");
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[5]/td[2]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[6]/td[1]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[6]/td[1]/input").Click();

            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[4]/td[4]/input").Click();

            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[5]/td[2]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[4]/td[2]/input").Click();

            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[2]/td[3]/input").Click();
            Find.ByXPath<HtmlInputButton>("//html/body/table/tbody/tr[6]/td[4]/input").Click();

            var result = Find.ById<HtmlInputText>("calc_result").Text;

            Assert.AreEqual("10000", result);   //200*25%=10000

            //Bug found: the percent is not calculated in javascript
        }

        #endregion

        #region Task 3: Kendo Demos

        [TestMethod]
        public void KendoDemosTest()
        {
            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://www.telerik.com/support/demos");

            // Navigate to Kendo UI demos
            Find.ByContent<HtmlAnchor>("Launch Kendo UI demos").Click();
            Assert.AreEqual("http://demos.telerik.com/kendo-ui/", Manager.ActiveBrowser.Url);

            // Navigate to Grid -> Initialization from table demo
            Find.ByContent<HtmlAnchor>("Grid").Click();
            Find.ByContent<HtmlAnchor>("Initialization from table").Click();
            Assert.AreEqual("http://demos.telerik.com/kendo-ui/grid/from-table", Manager.ActiveBrowser.Url);

            // Verify Grid is loaded and has X columns and Y rows
            var gridTable = Find.ById<HtmlTable>("grid");
            Assert.AreEqual(5, gridTable.ColumnCount);
            Assert.AreEqual(21, gridTable.Rows.Count);

            // Test sorting (grid is sorded via column headers)
            List<string> cars = new List<string>();
            foreach (var row in gridTable.Rows)
            {
                cars.Add(row.ChildNodes[0].InnerText);
            }
            cars.Sort();

            Find.ByContent<HtmlAnchor>("Car Make").Click();
            var sortedGridTable = Find.ById<HtmlTable>("grid");

            for (int row = 0; row < sortedGridTable.Rows.Count; row++)
            {
                Assert.AreEqual(cars[row], sortedGridTable.Rows[row].ChildNodes[0].InnerText, "The table is not sorted!");
            }
        }

        #endregion
    }
}