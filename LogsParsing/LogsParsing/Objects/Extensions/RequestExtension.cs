using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogsParsing.Objects.Extensions
{
    public static class RequestExtension
    {
        public static IEnumerable<IPAddress> GetUniqueIPs(this IEnumerable<Request> requests)
        {
            return requests.Select(r => r.Address).Distinct();        
        }

        public static IEnumerable<RequestsCounter> SortAddresses(this IEnumerable<Request> requests, DateTime timeStart, DateTime timeEnd)
        {
            List<Request> filteredRequestsByTime = requests.Where(r => (timeStart <= r.RequestTime && r.RequestTime <= timeEnd)).ToList();
            List<IPAddress> uniqueAddresses = filteredRequestsByTime.GetUniqueIPs().ToList();

            List<RequestsCounter> result = new List<RequestsCounter>();

            foreach (IPAddress address in uniqueAddresses)
            {
                int countRequests = filteredRequestsByTime.Count(r => r.Address.Equals(address));
                result.Add(new RequestsCounter(address, countRequests));
            }

            return result;
        }
    }
}
