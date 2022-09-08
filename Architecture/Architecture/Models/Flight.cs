using System;

namespace Architecture.Models
{
    public class Flight
    {
        string _AirportStart;
        string _AirportArrival;
        int _Price;

        public Flight(string airportStart, string airportArrival, int price)
        {
            AirportStart = airportStart;
            AirportArrival = airportArrival;
            Price = price;
        }

        public int Price { get => _Price; set => _Price = value; }
        public string AirportArrival { get => _AirportArrival; set => _AirportArrival = value; }
        public string AirportStart { get => _AirportStart; set => _AirportStart = value; }
    }
}
