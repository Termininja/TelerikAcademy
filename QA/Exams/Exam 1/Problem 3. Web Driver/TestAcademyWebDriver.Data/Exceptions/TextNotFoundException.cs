﻿namespace TaWebDriver.Data.Exceptions
{
    using System;
    using System.Text;

    public class TextNotFoundException : ApplicationException
    {
        public TextNotFoundException()
        {
        }

        public TextNotFoundException(string textToFind, BaseTestDriver ext, Exception ex)
        {
            string message = this.BuildTextNotFoundExceptionText(textToFind, ext);

            throw new ApplicationException(message, ex);
        }

        public TextNotFoundException(string textToFind, BaseTestDriver ext)
        {
            string message = this.BuildTextNotFoundExceptionText(textToFind, ext);

            throw new ApplicationException(message);
        }

        private string BuildTextNotFoundExceptionText(string textToFind, BaseTestDriver ext)
        {
            StringBuilder sb = new StringBuilder();

            string customLoggingMessage =
                String.Format("#### The text:  {0} ####\n ####WAS NOT FOUND!####", textToFind);
            sb.AppendLine(customLoggingMessage);

            string cuurentUrlMessage = String.Format("The URL when the test failed was: {0}", ext.Browser.Url);
            sb.AppendLine(cuurentUrlMessage);

            return sb.ToString();
        }
    }
}
