using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogsParsing.Objects
{
    internal class RequestLog
    {
        internal RequestLog(IPAddress address, DateTime requestTime)
        {
            Address = address;
            RequestTime = requestTime;
        }
        internal RequestLog(string address, string requestTime)
        {
            Address = IPAddress.Parse(address);
            RequestTime = DateTime.Parse(requestTime);
        }
        public IPAddress Address { get; set; }
        public DateTime RequestTime {  get; set; }
    }
}
