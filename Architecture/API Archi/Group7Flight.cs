using System;

namespace API_Archi
{
    public class Group7Flight
    {
        public string id { get; set; }

        public string departure { get; set; }

        public string arrival { get; set; }

        public int price { get; set; }

        public Group7Flight(string id, string departure, string arrival, int price)
        {
            this.id = id;
            this.departure = departure;
            this.arrival = arrival;
            this.price = price;
        }
    }
}