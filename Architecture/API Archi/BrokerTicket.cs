using System;
using System.Collections.Generic;

namespace API_Archi
{
    public class BrokerTicket
    {
        public string flight_code { get; set; }

        public BrokerPerson person { get; set; }

        public int price { get; set; }

        public string booking_date { get; set; } //"23/09/2022"

        public List<BrokerAvailableOptions> option_codes { get; set; }

        public BrokerTicket(string flight_code, BrokerPerson person, int price, string booking_date, List<BrokerAvailableOptions> option_codes)
        {
            this.flight_code = flight_code;
            this.person = person;
            this.price = price;
            this.booking_date = booking_date;
            this.option_codes = option_codes;
        }
    }
}