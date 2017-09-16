namespace TaWebDriver.Data.Pages
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class MainNavigation
    {
        [FindsBy(How = How.Id, Using = "LoginButton")]
        public IWebElement LoginButton { get; set; }

        public void Login(BaseTestDriver driver, IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
            this.LoginButton.Click();
            driver.Wait();
        }
    }
}
