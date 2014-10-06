namespace TaWebDriver.Data.Exceptions
{
    using System;
    using System.Text;

    using OpenQA.Selenium;

    public class StillCheckedException : ApplicationException
    {
        public StillCheckedException()
        {
        }

        public StillCheckedException(By by, BaseTestDriver ext, Exception ex)
        {
            string message = this.BuildStillCheckedExceptionText(by, ext);

            throw new ApplicationException(message, ex);
        }

        public StillCheckedException(By by, BaseTestDriver ext)
        {
            string message = this.BuildStillCheckedExceptionText(by, ext);

            throw new ApplicationException(message);
        }

        private string BuildStillCheckedExceptionText(By by, BaseTestDriver ext)
        {
            StringBuilder sb = new StringBuilder();

            string customLoggingMessage =
                String.Format("#### The element with the location strategy:  {0} ####\n ####WAS CHECKED!####",
                    by.ToString());
            sb.AppendLine(customLoggingMessage);

            string cuurentUrlMessage = String.Format("The URL when the test failed was: {0}", ext.Browser.Url);
            sb.AppendLine(cuurentUrlMessage);

            return sb.ToString();
        }
    }
}
