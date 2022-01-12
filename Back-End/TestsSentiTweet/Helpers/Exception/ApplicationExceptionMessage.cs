using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using WebAPI.Helpers;


namespace TestsSentiTweet.Helpers.Exception
{
    [TestClass]
    public class ApplicationExceptionMessage
    {
        public const string MESSAGE = "EXCEPTION_TEXT";

        [TestMethod]
        public void TestExceptionWithMessage()
        {
            AppException exception = new AppException(MESSAGE);

            Assert.AreEqual(
                exception.Message,
                MESSAGE,
                "Wrong exception message"
                );
        }

        [TestMethod]
        public void TestExceptionWithoutMessage()
        {
            AppException exception = new AppException();

            Assert.AreNotEqual(
                exception.Message,
                "",
                "Wrong exception message"
                );
        }

    }
}
