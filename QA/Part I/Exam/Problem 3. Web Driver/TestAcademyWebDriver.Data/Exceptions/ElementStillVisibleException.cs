namespace TaWebDriver.Data.Exceptions
{
    using OpenQA.Selenium;

    using System;
    using System.Text;

    public class ElementStillVisibleException : ApplicationException
    {
        public ElementStillVisibleException()
        {
        }

        public ElementStillVisibleException(By by, BaseTestDriver ext, Exception ex)
        {
            string message = this.BuildElementStillVisibleExceptionText(by, ext);

            throw new ApplicationException(message, ex);
        }

        public ElementStillVisibleException(By by, BaseTestDriver ext)
        {
            string message = this.BuildElementStillVisibleExceptionText(by, ext);

            throw new ApplicationException(message);
        }

        private string BuildElementStillVisibleExceptionText(By by, BaseTestDriver ext)
        {
            StringBuilder sb = new StringBuilder();

            string customLoggingMessage =
                String.Format("#### The element with the location strategy:  {0} ####\n ####IS STILL VISIBLE!####",
                    by.ToString());
            sb.AppendLine(customLoggingMessage);

            string cuurentUrlMessage = String.Format("The URL when the test failed was: {0}", ext.Browser.Url);
            sb.AppendLine(cuurentUrlMessage);

            return sb.ToString();
        }
    }
}
