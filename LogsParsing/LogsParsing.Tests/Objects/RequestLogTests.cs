using LogsParsing.Objects;
using System.Net;

namespace LogsParsing.Tests.Objects
{
    [TestClass]
    public class RequestLogTests
    {
        [TestMethod]
        public void TryCreateRequestLog_FromSpecificObjects()
        {
            IPAddress testAddress = IPAddress.Parse("127.0.0.0");
            DateTime testTime = DateTime.Parse("2024-04-08 12:00");

            RequestLog requestLog = new RequestLog(testAddress, testTime);

            Assert.IsNotNull(requestLog);
        }

        [TestMethod]
        public void TryCreateRequestLog_FromText()
        {
            string testAddress = "127.0.0.0";
            string testTime = "2024-04-08 12:00";

            RequestLog requestLog = new RequestLog(testAddress, testTime);

            Assert.IsNotNull(requestLog);
        }
    }
}