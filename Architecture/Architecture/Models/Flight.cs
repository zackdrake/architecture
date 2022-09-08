using System;

namespace Architecture.Models
{
    public class Flight
    {
        int _ID;
        string _AirportStart;
        string _AirportArrival;
        int _Price;

        public Flight(int id, string airportStart, string airportArrival, int price)
        {
            ID = id;
            AirportStart = airportStart;
            AirportArrival = airportArrival;
            Price = price;
        }

        public int Price { get => _Price; set => _Price = value; }
        public string AirportArrival { get => _AirportArrival; set => _AirportArrival = value; }
        public string AirportStart { get => _AirportStart; set => _AirportStart = value; }
        public int ID { get => _ID; set => _ID = value; }
    }
}
