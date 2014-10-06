namespace TaWebDriver.Tests
{
    using System;
    using System.Diagnostics;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;

    using TaWebDriver.Data;
    using TaWebDriver.Data.Pages;

    [TestClass]
    public class UnitTest : BaseTestDriver
    {
        private const int WaitingTime = 10;

        private MainNavigation mainNavigation;
        private LoginPage loginPage;

        [TestInitialize]
        public void TestInitialize()
        {
            this.Init(new ChromeDriver(@"..\..\"), @"http://test.telerikacademy.com", WaitingTime);
            this.mainNavigation = new MainNavigation();
            this.loginPage = new LoginPage();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            try
            {
                this.Browser.Quit();
            }
            catch (Exception ex)
            {
                this.Log.Error(ex.Message);
            }
        }

        [TestMethod]
        public void SoftwareAcademyCandidateTest()
        {
            this.mainNavigation.Login(this, this.Browser);
            this.loginPage.LoginWithDefaultUser(this, this.Browser);

            DeleteCandidature();

            this.NavigateTo("http://test.telerikacademy.com/SoftwareAcademy/Candidate");

            SetValue("FirstName", "Нинджа", true);
            SetValue("SecondName", "Тест", true);
            SetValue("LastName", "Юзър", true);
            SetValue("Picture", @"C:\Users\Administrator\Desktop\TelerikAcademyWebDriver\TestAcademyWebDriver.Data\Resources\image.jpg", false);

            CheckBox("IsMale_True");

            SetValue("Email", "xxx@xxx.xxx", true);
            SetValue("Phone", "0888888888", true);
            SetValue("SchoolName", "Тест", true);

            for (int i = 1; i <= 5; i++)
            {
                SetValue("Question_" + i, "Тест тест тест тест тест тест " + i, true);
            }

            int[] indexes = { 1, 9, 16, 24, 39, 42 };
            for (int i = 0; i < indexes.Length; i++)
            {
                CheckBox("Answer_" + indexes[i]);
            }

            string[] ids = { "CV", "CoverLetter", "AdditionalDocuments" };
            for (int i = 1; i < 3; i++)
            {
                SetValue(ids[i - 1], @"C:\Users\Administrator\Desktop\TelerikAcademyWebDriver\TestAcademyWebDriver.Data\Resources\doc" + i + ".docx", false);
            }

            CheckBox("AcceptTerms");
            CheckBox("SendButton");

            this.Wait();

            this.NavigateTo("http://test.telerikacademy.com/Administration_SoftwareAcademy/Candidates");

            CheckCandidature();

            DeleteCandidature();
        }

        private void SetValue(string id, string value, bool clear)
        {
            this.CurrentElement = this.GetElement(By.Id(id));
            if (clear)
            {
                this.CurrentElement.Clear();
            }

            this.CurrentElement.SendKeys(value);
        }
        
        private void CheckBox(string id)
        {
            this.CurrentElement = this.GetElement(By.Id(id));
            this.CurrentElement.Click();
        }

        private void CheckCandidature()
        {
            var myElement = this.GetElements(By.XPath("//td[contains(text(),'xxx@xxx.xxx')]/preceding-sibling::td[7]"))[0];
            this.CurrentElement = myElement.FindElement(By.TagName("a"));
            this.CurrentElement.Click();

            this.CurrentElement = myElement.FindElement(By.XPath("..")).FindElement(By.XPath("./following-sibling::tr[1]"));
            this.CurrentElement = this.CurrentElement.FindElement(By.XPath("//a[contains(text(),'xxx@xxx.xxx')]"));

            Assert.AreEqual("xxx@xxx.xxx", this.CurrentElement.Text);
        }

        private void DeleteCandidature()
        {
            this.NavigateTo("http://test.telerikacademy.com/Administration_SoftwareAcademy/Candidates");

            this.CurrentElement = this.GetElement(By.XPath("/html/body/div[1]/div/section/div[1]/form/fieldset/input[1]"));
            this.CurrentElement.Clear();
            this.CurrentElement.SendKeys("xxx@xxx.xxx");
            this.CurrentElement = this.GetElement(By.XPath("//html/body/div[1]/div/section/div[1]/form/fieldset/input[2]"));
            this.CurrentElement.Click();
            this.Wait();
        }
    }
}