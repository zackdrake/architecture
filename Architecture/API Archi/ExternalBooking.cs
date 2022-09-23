using System;

namespace API_Archi
{
    public class ExternalBooking
    {
        public ExternalFlight flight { get; set; }

        public DateTime date { get; set; }

        public int payed_price { get; set; }

        public string customer_name { get; set; }

        public string customer_nationality { get; set; }

        public string booking_source { get; set; }

        public ExternalBooking(ExternalFlight flight, DateTime date, int payed_price, string customer_name, string customer_nationality, string booking_source)
        {
            this.flight = flight;
            this.date = date;
            this.payed_price = payed_price;
            this.customer_name = customer_name;
            this.customer_nationality = customer_nationality;
            this.booking_source = booking_source;
        }
    }
}