using System;

namespace API_Archi
{
    public class ExternalBooking
    {
        public string code { get; set; }

        public ExternalFlight flight { get; set; }

        public string date { get; set; }

        public int payed_price { get; set; }

        public string customer_name { get; set; }

        public string customer_nationality { get; set; }

        public ExternalFlightOptions[] options { get; set; }

        public string booking_source { get; set; }

        public ExternalBooking(string code, ExternalFlight flight, string date, int payed_price, string customer_name, string customer_nationality, ExternalFlightOptions[] options, string booking_source)
        {
            this.code = code;
            this.flight = flight;
            this.date = date;
            this.payed_price = payed_price;
            this.customer_name = customer_name;
            this.customer_nationality = customer_nationality;
            this.options = options;
            this.booking_source = booking_source;
        }
    }
}