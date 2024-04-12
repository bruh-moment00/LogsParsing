using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LogsParsing.Requests.Extensions;
using LogsParsing.Requests.Objects;
using LogsParsing.RequestsCounters.Objects;

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
    }
}
