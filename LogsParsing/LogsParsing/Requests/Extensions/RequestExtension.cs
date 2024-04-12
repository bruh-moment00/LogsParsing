using LogsParsing.Requests.Objects;
using LogsParsing.RequestsCounters.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogsParsing.Requests.Extensions
{
    public static class RequestExtension
    {
        public static IEnumerable<IPAddress> GetUniqueIPs(this IEnumerable<Request> requests)
        {
            return requests.Select(r => r.Address).Distinct();
        }

        public static IEnumerable<RequestsCounter> SortAddresses(this IEnumerable<Request> requests, DateTime timeStart, DateTime timeEnd)
        {
            List<Request> filteredRequestsByTime = requests.Where(r => timeStart <= r.RequestTime && r.RequestTime <= timeEnd).ToList();
            List<IPAddress> uniqueAddresses = filteredRequestsByTime.GetUniqueIPs().ToList();

            List<RequestsCounter> result = new List<RequestsCounter>();

            foreach (IPAddress address in uniqueAddresses)
            {
                int countRequests = filteredRequestsByTime.Count(r => r.Address.Equals(address));
                result.Add(new RequestsCounter(address, countRequests));
            }

            return result;
        }

        public static IEnumerable<RequestsCounter> SortAddresses(this IEnumerable<Request> requests, DateTime timeStart, DateTime timeEnd, IPAddress addressStart, IPAddress addressMask)
        {
            List<Request> filteredRequestsByTime = requests.Where(r => timeStart <= r.RequestTime && r.RequestTime <= timeEnd).ToList();
            List<IPAddress> uniqueAddresses = filteredRequestsByTime.GetUniqueIPs().InRange(addressStart, addressMask).ToList();

            List<RequestsCounter> result = new List<RequestsCounter>();

            foreach (IPAddress address in uniqueAddresses)
            {
                int countRequests = filteredRequestsByTime.Count(r => r.Address.Equals(address));
                result.Add(new RequestsCounter(address, countRequests));
            }

            return result;
        }

        public static IEnumerable<RequestsCounter> SortAddresses(this IEnumerable<Request> requests, string timeStart, string timeEnd)
        {
            DateTime convertTimeStart = DateTime.ParseExact(timeStart, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime convertTimeEnd = DateTime.ParseExact(timeEnd, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);

            return requests.SortAddresses(convertTimeStart, convertTimeEnd);
        }

        public static IEnumerable<RequestsCounter> SortAddresses(this IEnumerable<Request> requests, string timeStart, string timeEnd, IPAddress addressStart, IPAddress addressMask)
        {
            DateTime convertTimeStart = DateTime.ParseExact(timeStart, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime convertTimeEnd = DateTime.ParseExact(timeEnd, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);

            return requests.SortAddresses(convertTimeStart, convertTimeEnd, addressStart, addressMask);
        }

        public static Request ToRequestType(this string request)
        {
            string date = request.Substring(0, request.LastIndexOf(':')).Trim();
            string address = request.Substring(request.LastIndexOf(':') + 1).Trim();
            return new Request(address, date);
        }
    }
}
