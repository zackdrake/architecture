using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API_Archi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreBookingController : Controller
    {
        private static double luggageValue = 0.9;
        private static double childReduceValue = 50;
        private static int groupReduceNb = 6;
        private static double groupReduceValue = 0.97;
        private static double escaleReduceValue = 0.85;
        private static double trainValue = 30;
        private static double firstClassValue = 50;

        public enum MoneyRef
        {
            USD, JPY, BGN, CZK, DKK,
            GBP, HUF, PLN, RON, SEK,
            CHF, ISK, NOK, HRK, TRY,
            AUD, BRL, CAD, CNY, HKD,
            IDR, ILS, INR, KRW, MXN,
            MYR, NZD, PHP, SGD, THB,
            ZAR
        }

        // http://localhost:52880/PreBooking/convert
        [HttpGet("convert")]
        public Dictionary<MoneyRef, double> PriceConverted()
        {
            return new Dictionary<MoneyRef, double>()
            {
                { MoneyRef.USD, 0.9954 }, { MoneyRef.JPY, 142.53 }, { MoneyRef.BGN, 1.9558 },
                { MoneyRef.CZK, 24.497 }, { MoneyRef.DKK, 7.4366 }, { MoneyRef.GBP, 0.87400 },
                { MoneyRef.HUF, 403.98 }, { MoneyRef.PLN, 4.7143 }, { MoneyRef.RON, 4.9238 },
                { MoneyRef.SEK, 10.7541 }, { MoneyRef.CHF, 0.9579 }, { MoneyRef.ISK, 138.30 },
                { MoneyRef.NOK, 10.1985 }, { MoneyRef.HRK, 7.5235 }, { MoneyRef.TRY, 18.1923 },
                { MoneyRef.AUD, 1.4894 }, { MoneyRef.BRL, 5.2279 }, { MoneyRef.CAD, 1.3226 },
                { MoneyRef.CNY, 6.9787 }, { MoneyRef.HKD, 7.8133 }, { MoneyRef.IDR, 14904.67 },
                { MoneyRef.ILS, 3.4267 }, { MoneyRef.INR, 79.3605 }, { MoneyRef.KRW, 1383.58 },
                { MoneyRef.MXN, 20.0028 }, { MoneyRef.MYR, 4.5141 }, { MoneyRef.NZD, 1.6717 },
                { MoneyRef.PHP, 57.111 }, { MoneyRef.SGD, 1.4025 }, { MoneyRef.THB, 36.800 },
                { MoneyRef.ZAR, 17.6004 }
            };
        }

        // http://localhost:52880/PreBooking/price
        [HttpPut("price")]
        public double Price(PreBooking bill)
        {
            Flight flight = new FlightController().GetFlightById(bill.FlightId);

            double price = flight.price;

            if (bill.luggage)
            {
                price = luggageReduction(price);
            }
            if (bill.childReduction)
            {
                price = childReduction(price);
            }
            if (flight.Next !=  null)
            {
                price = escaleReduction(price);
            }
            if (flight.IsThereATrain())
            {
                price = trainReduction(price);

                if (bill.trainFirstClassOption)
                {
                    price = firstClassReduction(price);
                }
            }

            if (price > 0)
            {
                return price;
            }
            throw new APIExeption(APIExeption.ExeptionType.IllegalPrice);
        }

        // http://localhost:52880/PreBooking/cartprice
        [HttpPut("cartprice")]
        public double CartPrice(List<PreBooking> bills)
        {
            (Dictionary<string, int> dictionary, double price) = BillsRegroupedCalcul(bills);

            bool trigger = false;

            foreach (KeyValuePair<string, int> keyValuePair in dictionary)
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

            if (price > 0)
            {
                return price;
            }
            throw new APIExeption(APIExeption.ExeptionType.IllegalPrice);
        }

        private (Dictionary<string, int>, double) BillsRegroupedCalcul(List<PreBooking> bills)
        {
            double price = 0;
            Dictionary<string, int> dictionary = new();

            foreach (PreBooking bill in bills)
            {
                price += Price(bill);
                if (dictionary.ContainsKey(bill.FlightId))
                {
                    int i = dictionary.GetValueOrDefault(bill.FlightId) + 1;
                    dictionary.Remove(bill.FlightId);
                    dictionary.Add(bill.FlightId, i);
                }
                else
                {
                    dictionary.Add(bill.FlightId, 1);
                }
            }
            return (dictionary, price);
        }

        private double luggageReduction(double price)
        {
            price *= luggageValue;

            return price;
        }

        private double childReduction(double price)
        {
            price += childReduceValue;

            return price;
        }

        private double escaleReduction(double price)
        {
            price *= escaleReduceValue;

            return price;
        }

        private double trainReduction(double price)
        {
            price += trainValue;

            return price;
        }

        private double firstClassReduction(double price)
        {
            price += firstClassValue;

            return price;
        }
    }
}
