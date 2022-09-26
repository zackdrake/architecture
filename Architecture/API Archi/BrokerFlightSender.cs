using System;
using System.Collections.Generic;

namespace API_Archi
{
    public class BrokerFlightSender
    {
        public string provider_key { get; set; }
        public List<BrokerFlight> flights { get; set; }
        public BrokerFlightSender(string provider_key, List<BrokerFlight> flights)
        {
            this.provider_key = provider_key;
            this.flights = flights;
        }
    }
}