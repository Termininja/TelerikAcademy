namespace TaWebDriver.Data
{
    using System;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using TaWebDriver.Data.Exceptions;

    public class BaseTestDriver
    {
        protected readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IWebDriver Browser { get; set; }

        public StringBuilder VerificationErrors { get; set; }

        public WebDriverWait WebDriverWait { get; set; }

        public IWebElement CurrentElement { get; set; }

        public int TimeToWait { get; set; }

        public void Init(IWebDriver driver, string baseUrl, int timeOut)
        {
            this.Browser = driver;
            this.Browser.Url = baseUrl;
            this.WebDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            this.TimeToWait = timeOut;
        }

        public void NavigateTo(string url)
        {
            this.Browser.Navigate().GoToUrl(url);
        }

        public IWebElement GetElement(By by)
        {
            IWebElement element = null;
            try
            {
                element = this.WebDriverWait.Until(x => x.FindElement(by));
            }
            catch (TimeoutException ex)
            {
                Log.Error(ex.Message);
                throw new TaWebDriver.Data.Exceptions.NoSuchElementException(by, this, ex);
            }

            return element;
        }

        public ReadOnlyCollection<IWebElement> GetElements(By by)
        {
            ReadOnlyCollection<IWebElement> elements = null;
            try
            {
                elements = this.WebDriverWait.Until(x => x.FindElements(by));
            }
            catch (TimeoutException ex)
            {
                Log.Error(ex.Message);
                throw new TaWebDriver.Data.Exceptions.NoSuchElementException(by, this, ex);
            }

            return elements;
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                this.Browser.FindElement(by);
                return true;
            }
            catch (TaWebDriver.Data.Exceptions.NoSuchElementException ex)
            {
                Log.Error(ex.Message);
                return false;
            }
        }

        public void Wait(int? time = null)
        {
            var timeToWait = time ?? this.TimeToWait;
            this.Browser.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeToWait));
        }

        public void WaitForElementPresent(By by)
        {
            this.GetElement(by);
        }

        public void WaitForElementNotPresent(By by)
        {
            try
            {
                this.GetElement(by);
                throw new ElementStillVisibleException(by, this);
            }
            catch (TaWebDriver.Data.Exceptions.NoSuchElementException ex)
            {
                Log.Error(ex.Message);

                return;
            }
        }

        public void WaitForChecked(By by)
        {
            IWebElement currentElement = this.GetElement(by);
            bool isSelected = currentElement.Selected;

            if (!isSelected)
            {
                Log.ErrorFormat("The element with find expression {0} was not checked.", by.ToString());
                throw new NotCheckedException(by, this);
            }
        }

        public void WaitForNotChecked(By by)
        {
            IWebElement currentElement = this.GetElement(by);
            bool isSelected = currentElement.Selected;

            if (!isSelected)
            {
                Log.ErrorFormat("The element with find expression {0} was checked.", by.ToString());
                throw new StillCheckedException(by, this);
            }
        }

        public void WaitForTextPresent(string textToFind, bool shouldWait = true)
        {
            for (int second = 0; ; second++)
            {
                if (second >= this.TimeToWait)
                {
                    Log.ErrorFormat("The following text: {0}\n was not found on the page.", textToFind);
                    throw new TextNotFoundException(textToFind, this);
                }

                try
                {
                    string bodyInnerHtml = this.Browser.FindElement(By.TagName("body")).Text;
                    bool isContainingText = bodyInnerHtml.Contains(textToFind);
                    Assert.AreEqual(shouldWait, isContainingText);

                    break;
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                }

                Thread.Sleep(1000);
            }
        }

        public void WaitForText(By by, string textToFind)
        {
            IWebElement currentElement = this.GetElement(by);
            string elementText = currentElement.Text;

            if (!textToFind.Equals(elementText))
            {
                Log.ErrorFormat("The following text: {0}\n was not found on the page.", textToFind);
                throw new TextNotFoundException(textToFind, this);
            }
        }

        public void WaitForTextNotPresent(string textToFind)
        {
            this.WaitForTextPresent(textToFind, false);
        }
    }
}