using System;
using System.Collections.Generic;

namespace API_Archi
{
    public class BrokerFlight
    {
        public string tenant { get; set; }

        public string departure { get; set; }

        public string arrival { get; set; }

        public string internal_code { get; set; }

        public List<BrokerAvailableOptions> available_options { get; set; }

        public List<string> stop_overs { get; set; } //List of airports : "JFK", "CDG", ...

        public int total_seats { get; set; }

        public int price { get; set; }
        
        public BrokerFlight(string tenant, string departure, string arrival, string internal_code, List<BrokerAvailableOptions> available_options, List<string> stop_overs, int total_seats, int price)
        {
            this.tenant = tenant;
            this.departure = departure;
            this.arrival = arrival;
            this.internal_code = internal_code;
            this.available_options = available_options;
            this.stop_overs = stop_overs;
            this.total_seats = total_seats;
            this.price = price;
        }
    }
}
