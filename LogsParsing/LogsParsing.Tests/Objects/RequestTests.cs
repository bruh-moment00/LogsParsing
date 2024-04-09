using LogsParsing.Objects;
using System.Net;

namespace LogsParsing.Tests.Objects
{
    [TestClass]
    public class RequestTests
    {
        [TestMethod]
        public void TryCreateRequestLog_FromSpecificObjects()
        {
            IPAddress testAddress = IPAddress.Parse("127.0.0.0");
            DateTime testTime = DateTime.Parse("2024-04-08 12:00:10");

            Request requestLog = new Request(testAddress, testTime);

            Assert.IsNotNull(requestLog);
        }

        [TestMethod]
        public void TryCreateRequestLog_FromString()
        {
            string testAddress = "127.0.0.0";
            string testTime = "2024-04-08 12:00:10";

            Request requestLog = new Request(testAddress, testTime);

            Assert.IsNotNull(requestLog);
        }

        [TestMethod]
        public void TryGetAddress_CreatedFromObjects()
        {
            IPAddress testAddress = IPAddress.Parse("127.0.0.0");
            DateTime testTime = DateTime.Parse("2024-04-08 12:00:10");

            string expected = "127.0.0.0";

            Request requestLog = new Request(testAddress, testTime);

            Assert.AreEqual(expected, requestLog.Address.ToString());
        }

        [TestMethod]
        public void TryGetAddress_CreatedFromString()
        {
            string testAddress = "127.0.0.0";
            string testTime = "2024-04-08 12:00:10";

            string expected = "127.0.0.0";

            Request requestLog = new Request(testAddress, testTime);

            Assert.AreEqual(expected, requestLog.Address.ToString());
        }

        [TestMethod]
        public void TryGetDateAndTime_CreatedFromObjects()
        {
            IPAddress testAddress = IPAddress.Parse("127.0.0.0");
            DateTime testTime = DateTime.Parse("2024-04-08 05:00:10");

            string expected = "2024-04-08 05:00:10";

            Request requestLog = new Request(testAddress, testTime);

            Assert.AreEqual(expected, requestLog.RequestTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        [TestMethod]
        public void TryGetDateAndTime_CreatedFromString()
        {
            string testAddress = "127.0.0.0";
            string testTime = "2024-04-08 05:00:10";

            string expected = "2024-04-08 05:00:10";

            Request requestLog = new Request(testAddress, testTime);

            Assert.AreEqual(expected, requestLog.RequestTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}