using System;

namespace API_Archi
{
    public class Flight
    {
        public int id { get; set; }

        public string airport_start { get; set; }

        public string airport_arrival { get; set; }

        public int price { get; set; }

        public int nb_max_places { get; set; }

        public Flight(int id, string airport_start, string airport_arrival, int price, int nb_max_places)
        {
            this.id = id;
            this.airport_start = airport_start;
            this.airport_arrival = airport_arrival;
            this.price = price;
            this.nb_max_places = nb_max_places;
        }
    }
}