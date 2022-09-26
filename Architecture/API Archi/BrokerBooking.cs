using System;

namespace API_Archi
{
    public class BrokerBooking
    {
        public int total_price { get; set; }

        public BrokerCurrency currency { get; set; }

        public BrokerTicket[] tickets { get; set; }

        public BrokerBooking(int total_price, BrokerCurrency currency, BrokerTicket[] tickets)
        {
            this.total_price = total_price;
            this.currency = currency;
            this.tickets = tickets;
        }
    }
}