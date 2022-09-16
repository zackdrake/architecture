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

        private static Dictionary<MoneyRef, double> converter => new Dictionary<MoneyRef, double>() 
        {
            { MoneyRef.USD, 0.9954 },
            { MoneyRef.JPY, 142.53 },
            { MoneyRef.BGN, 1.9558 },
            { MoneyRef.CZK, 24.497 },
            { MoneyRef.DKK, 7.4366 },
            { MoneyRef.GBP, 0.87400 },
            { MoneyRef.HUF, 403.98 },
            { MoneyRef.PLN, 4.7143 },
            { MoneyRef.RON, 4.9238 },
            { MoneyRef.SEK, 10.7541 },
            { MoneyRef.JPY, 0.9579 },
            { MoneyRef.BGN, 138.30 },
            { MoneyRef.USD, 10.1985 },
            { MoneyRef.JPY, 7.5235 },
            { MoneyRef.BGN, 18.1923 },
            { MoneyRef.USD, 1.4894 },
            { MoneyRef.JPY, 5.2279 },
            { MoneyRef.BGN, 1.3226 },
            { MoneyRef.USD, 6.9787 },
            { MoneyRef.JPY, 7.8133 },
            { MoneyRef.BGN, 14904.67 },
            { MoneyRef.USD, 3.4267 },
            { MoneyRef.JPY, 79.3605 },
            { MoneyRef.BGN, 1383.58 },
            { MoneyRef.BGN, 20.0028 },
            { MoneyRef.USD, 4.5141 },
            { MoneyRef.JPY, 1.6717 },
            { MoneyRef.BGN, 57.111 },
            { MoneyRef.USD, 1.4025 },
            { MoneyRef.JPY, 36.800 },
            { MoneyRef.BGN, 17.6004 }
        };

        private enum MoneyRef
        {
            USD,
            JPY,
            BGN,
            CZK,
            DKK,
            GBP,
            HUF,
            PLN,
            RON,
            SEK,//
            CHF,
            ISK,
            NOK,
            HRK,
            TRY,
            AUD,
            BRL,
            CAD,
            CNY,
            HKD,
            IDR,
            ILS,
            INR,
            KRW,
            MXN,
            MYR,
            NZD,
            PHP,
            SGD,
            THB,
            ZAR
        }

        // http://localhost:52880/Bill/price
        [HttpGet("price")]
        public double Price(Bill bill)
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
        public double CartPrice(List<Bill> bills)
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
        public double PriceConverted(double price)
        {
            price *= dollarConverter;

            return price;
        }
    }
}
