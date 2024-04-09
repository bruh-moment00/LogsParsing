using LogsParsing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogsParsing.Objects
{
    public class RequestsCounter
    {
        public RequestsCounter(IPAddress iPAddress)
        {
            IPAddress = iPAddress;
            RequestsCount = 0;
        }
        public RequestsCounter(IPAddress iPAddress, int requestsCount)
        {
            IPAddress = iPAddress;
            RequestsCount = requestsCount;
        }
        public IPAddress IPAddress { get; set; }
        public int RequestsCount {  get; set; }
    }
}


