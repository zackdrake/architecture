using System;

namespace API_Archi
{
    public class Flight
    {
        public int id { get; set; }

        public string Airport_start { get; set; }

        public string Airport_arrival { get; set; }

        public int price { get; set; }

        public int nbMaxPlaces { get; set; }

        public Flight(int _id, string _Airport_start, string _Airport_arrival, int _price, int _nbMaxPlaces)
        {
            id = _id;
            Airport_start = _Airport_start;
            Airport_arrival = _Airport_arrival;
            price = _price;
            nbMaxPlaces = _nbMaxPlaces;
        }
    }
}
