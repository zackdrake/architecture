using System;

namespace API_Archi
{
    public class ExternalFlight
    {
        public string code { get; set; }

        public string departure { get; set; }

        public string arrival { get; set; }

        public int base_price { get; set; }

        public ExternalPlane plane { get; set; }

        public ExternalFlight(string code, string departure, string arrival, int base_price, ExternalPlane plane)
        {
            this.code = code;
            this.departure = departure;
            this.arrival = arrival;
            this.base_price = base_price;
            this.plane = plane;
        }
    }
}
