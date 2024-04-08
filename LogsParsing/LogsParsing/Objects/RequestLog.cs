﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogsParsing.Objects
{
    public class RequestLog
    {
        public RequestLog(IPAddress address, DateTime requestTime)
        {
            Address = address;
            this.RequestTime = requestTime;
        }
        public RequestLog(string address, string requestTime)
        {
            Address = IPAddress.Parse(address);
            RequestTime = DateTime.Parse(requestTime);
        }

        public IPAddress Address {  get; private set; }

        public DateTime RequestTime { get; private set; }
    }
}
