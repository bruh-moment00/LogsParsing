using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NetTools;

namespace LogsParsing.Requests.Extensions
{
    public static class IPAddressExtensions
    {
        public static bool IsInRange(this IPAddress ipAddress, IPAddress addressStart, int addressMask)
        {
            IPAddressRange range = new IPAddressRange(addressStart, addressMask);
            range.Begin = addressStart;
            return range.Contains(ipAddress);
        }

        public static IEnumerable<IPAddress> InRange(this IEnumerable<IPAddress> addresses, IPAddress rangeStart, int addressMask) 
        {
            List<IPAddress> result = new List<IPAddress>();
            foreach (IPAddress address in addresses)
            {
                if (address.IsInRange(rangeStart, addressMask)) 
                    result.Add(address);
            }

            return result;
        }
    }
}
