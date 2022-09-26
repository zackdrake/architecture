using System;

namespace API_Archi{
    
    public class BrokerAvailableOptions
    {
        public string name { get; set; }
        public string code { get; set; }
        public int price { get; set; }
        public BrokerAvailableOptions(string name, string code, int price){
            this.name = name;
            this.code = code;
            this.price = price;
        }
    }
}

