using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API_Archi.Controllers
{
    public class BillController : ControllerBase
    {
        private static double luggageValue = 0.9;
        private static double childReduceValue = 50;
        private static int groupReduceNb = 6;
        private static double groupReduceValue = 0.97;

        private static double dollarConverter = 0.99739157;

        // http://localhost:52880/Bill/price
        [HttpGet("price")]
        public static double Price(Bill bill)
        {
            double price = 0;

            List<Flight> flights = FlightController.ReadFlightContext();

            Flight flight = flights.Single(fl => fl.id == bill.flightId);

            price = flight.price;

            if (bill.luggage) { price *= luggageValue; }
            if (bill.childReduce) { price += childReduceValue; }

            return price;
        }

        // http://localhost:52880/Bill/cartprice
        [HttpGet("cartprice")]
        public static double CartPrice(List<Bill> bills)
        {
            double price = 0;
            Dictionary<int, int> dictionary = new();

            foreach(Bill bill in bills)
            {
                price += Price(bill);
                if (dictionary.ContainsKey(bill.flightId))
                {
                    dictionary.Add(bill.flightId, dictionary.GetValueOrDefault(bill.flightId) + 1);
                }
                else
                {
                    dictionary.Add(bill.flightId, 1);
                }
            }

            bool trigger = false;

            foreach(KeyValuePair<int, int> keyValuePair in dictionary)
            {
                if (keyValuePair.Value >= groupReduceNb)
                {
                    trigger = true;
                }
            }

            if (trigger)
            {
                price *= groupReduceValue;
            }

            return price;
        }

        // http://localhost:52880/Bill/convert/50
        [HttpGet("convert/{price}")]
        public static double PriceConverted(double price)
        {
            price *= dollarConverter;

            return price;
        }
    }
}
