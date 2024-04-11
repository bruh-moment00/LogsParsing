using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogsParsing.Requests.Objects
{
    public class Request
    {
        public Request(IPAddress address, DateTime requestTime)
        {
            Address = address;
            RequestTime = requestTime;
        }
        public Request(string address, string requestTime)
        {
            Address = IPAddress.Parse(address);
            RequestTime = DateTime.Parse(requestTime);
        }

        public IPAddress Address { get; private set; }

        public DateTime RequestTime { get; private set; }
    }


}
