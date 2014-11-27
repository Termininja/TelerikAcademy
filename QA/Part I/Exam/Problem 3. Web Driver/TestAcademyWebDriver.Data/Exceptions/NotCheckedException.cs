namespace TaWebDriver.Data.Exceptions
{
    using System;
    using System.Text;

    using OpenQA.Selenium;

    public class NotCheckedException : ApplicationException
    {
        public NotCheckedException()
        {
        }

        public NotCheckedException(By by, BaseTestDriver ext, Exception ex)
        {
            string message = this.BuildNotCheckedExceptionText(by, ext);

            throw new ApplicationException(message, ex);
        }

        public NotCheckedException(By by, BaseTestDriver ext)
        {
            string message = this.BuildNotCheckedExceptionText(by, ext);

            throw new ApplicationException(message);
        }

        private string BuildNotCheckedExceptionText(By by, BaseTestDriver ext)
        {
            StringBuilder sb = new StringBuilder();

            string customLoggingMessage =
                String.Format("#### The element with the location strategy:  {0} ####\n ####WAS NOT CHECKED!####",
                    by.ToString());
            sb.AppendLine(customLoggingMessage);

            string cuurentUrlMessage = String.Format("The URL when the test failed was: {0}", ext.Browser.Url);
            sb.AppendLine(cuurentUrlMessage);

            return sb.ToString();
        }
    }
}
