using System;
using System.Collections.Generic;

namespace API_Archi
{
    public class BrokerBooking
    {
        public int total_price { get; set; }

        public BrokerCurrency currency { get; set; }

        public List<BrokerTicket> tickets { get; set; }

        public BrokerBooking(int total_price, BrokerCurrency currency, List<BrokerTicket> tickets)
        {
            this.total_price = total_price;
            this.currency = currency;
            this.tickets = tickets;
        }
    }
}