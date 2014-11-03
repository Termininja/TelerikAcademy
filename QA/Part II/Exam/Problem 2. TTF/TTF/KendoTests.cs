namespace TTF
{
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.TestTemplates;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class KendoTests : BaseTest
    {
        public TestContext TestContext { get; set; }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            Initialize(false, this.TestContext.TestLogsDir, new TestContextWriteLine(this.TestContext.WriteLine));
            SetTestMethod(this, (string)TestContext.Properties["TestName"]);

            Manager.LaunchNewBrowser(BrowserType.InternetExplorer);
            ActiveBrowser.NavigateTo("http://demos.telerik.com/aspnet-ajax/");
            Thread.Sleep(2000);

            var search = Find.ById<HtmlInputText>("DemoSearchControl_SearchBox_Input");
            search.MouseClick();
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            this.CleanUp();
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            ShutDown();
        }

        [TestMethod]
        public void KendoComboTest()
        {
            Search("Grid Filtered by Combo", "ComboBox - Grid Filtered by Combo");
            Paging("OrdersGrid");
        }

        [TestMethod]
        public void KendoAutomaticOperationsTest()
        {
            Search("Automatic Operations", "Grid - Automatic Operations");
            Paging("RadGrid1");
        }

        private void Paging(string pageID)
        {
            var page = Find.ById<HtmlAnchor>("ctl00_ContentPlaceHolder1_" + pageID + "_ctl00_ctl03_ctl01_PageSizeComboBox_Arrow");
            page.MouseClick();
            Thread.Sleep(2000);
            Desktop.KeyBoard.KeyPress(Keys.Down);
            Desktop.KeyBoard.KeyPress(Keys.Enter);
            Thread.Sleep(5000);

            var table = Find.ById<HtmlTable>("ctl00_ContentPlaceHolder1_" + pageID + "_ctl00");
            var rows = table.ChildNodes[3].ChildNodes.Count;

            //Assert.AreEqual(20, rows);
        }

        private void Search(string searchText, string assert)
        {
            Desktop.KeyBoard.TypeText(searchText);
            var x = Cursor.Position.X;
            var y = Cursor.Position.Y;
            Thread.Sleep(2000);

            Desktop.Mouse.Click(MouseClickType.LeftClick, new Point(x, y + 50));
            Thread.Sleep(2000);

            Manager.Browsers[0].Refresh();
            Thread.Sleep(2000);

            var label = Find.ById<HtmlSpan>("ctl00_DemoName").InnerText;
            Assert.AreEqual(assert, label);
        }
    }
}