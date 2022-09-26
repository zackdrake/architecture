using System;

namespace API_Archi{

    public class BrokerCurrency
    {
        public string currency_code { get; set; }
        public string currency_name { get; set; }
        public BrokerCurrency(string currency_code, string currency_name){
            this.currency_code = currency_code;
            this.currency_name = currency_name;
        }
    }
}

