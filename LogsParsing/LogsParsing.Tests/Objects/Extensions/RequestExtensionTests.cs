using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LogsParsing.Objects;
using LogsParsing.Objects.Extensions;

namespace LogsParsing.Tests.Objects.Extensions
{
    [TestClass]
    public class RequestExtensionTests
    {
        [TestMethod]
        public void TryGetUniqueIPs()
        {
            List<Request> requests = new List<Request>()
            {
                new Request("144.52.245.79", "2024-04-08 12:00:00"),
                new Request("50.214.129.7", "2024-04-08 12:00:00"),
                new Request("66.212.76.34", "2024-04-08 12:00:00"),
                new Request("144.52.245.79", "2024-04-08 12:00:00"),
                new Request("144.52.245.79", "2024-04-08 12:00:00"),
                new Request("50.214.129.7", "2024-04-08 12:00:00"),
                new Request("76.120.54.241", "2024-04-08 12:00:00"),
                new Request("90.45.202.112", "2024-04-08 12:00:00"),
            };

            List<IPAddress> expected = new List<IPAddress>()
            {
                IPAddress.Parse("144.52.245.79"),
                IPAddress.Parse("50.214.129.7"),
                IPAddress.Parse("66.212.76.34"),
                IPAddress.Parse("76.120.54.241"),
                IPAddress.Parse("90.45.202.112"),
            };

            List<IPAddress> result = requests.GetUniqueIPs().ToList();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TryCountRequests()
        {
            List<Request> requests = new List<Request>()
            {
                new Request("144.52.245.79", "2024-04-08 12:00:00"),
                new Request("50.214.129.7", "2024-04-08 12:00:00"),
                new Request("66.212.76.34", "2024-04-08 12:00:00"),
                new Request("144.52.245.79", "2024-04-09 12:00:00"),
                new Request("144.52.245.79", "2024-04-11 12:00:00"),
                new Request("50.214.129.7", "2024-04-08 12:00:00"),
                new Request("76.120.54.241", "2024-04-08 12:00:00"),
                new Request("90.45.202.112", "2024-04-08 12:00:00"),
                new Request("20.234.129.7", "2024-04-08 12:00:00"),
                new Request("76.190.54.241", "2024-04-05 12:00:00"),
                new Request("40.42.222.162", "2024-04-14 12:00:00"),
            };
            DateTime timeStart = DateTime.Parse("2024-04-08 00:00:00");
            DateTime timeEnd = DateTime.Parse("2024-04-10 00:00:00");

            List<RequestsCounter> expected = new List<RequestsCounter>()
            {
                new RequestsCounter(IPAddress.Parse("144.52.245.79"), 2),
                new RequestsCounter(IPAddress.Parse("50.214.129.7"), 2),
                new RequestsCounter(IPAddress.Parse("66.212.76.34"), 1),
                new RequestsCounter(IPAddress.Parse("76.120.54.241"), 1),
                new RequestsCounter(IPAddress.Parse("90.45.202.112"), 1),
                new RequestsCounter(IPAddress.Parse("20.234.129.7"), 1),
            };
            
            List<RequestsCounter> result = requests.SortAddresses(timeStart, timeEnd).ToList();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
