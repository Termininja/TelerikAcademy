namespace TaWebDriver.Data.Pages
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "UsernameOrEmail")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//html/body/div/div/section/form/fieldset/input")]
        public IWebElement LoginButton { get; set; }

        public void LoginWithDefaultUser(BaseTestDriver driver, IWebDriver browser, string name = "Ninja", string pass = "123456")
        {
            PageFactory.InitElements(browser, this);

            this.Username.Clear();
            this.Username.SendKeys(name);

            this.Password.Clear();
            this.Password.SendKeys(pass);

            this.LoginButton.Click();
            driver.Wait();
        }
    }
}
