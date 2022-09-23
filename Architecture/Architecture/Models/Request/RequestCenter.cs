using API_Archi;
using System;
using System.Collections.Generic;
using System.Text.Json;
using static API_Archi.Controllers.PreBookingController;

namespace Architecture.Models.Request
{
    public class RequestCenter
    {
        /// <summary>
        /// Flights
        /// </summary>
        public static List<Flight> GetFlights()
        {
            try
            {
                return JsonSerializer.Deserialize<List<Flight>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Flight, string.Empty));
            }
            catch (APIExeption e)
            {
                Console.WriteLine(e);
                return new List<Flight>();
            }
        }

        /// <summary>
        /// Bookings
        /// </summary>
        public static List<Booking> GetBookings()
        {
            try
            {
                return JsonSerializer.Deserialize<List<Booking>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Booking, string.Empty));
            }
            catch (APIExeption e)
            {
                Console.WriteLine(e);
                return new List<Booking>();
            }
        }

        public static Booking PostBooking(PreBooking preBooking, double totalPrice)
        {
            try
            {
                return JsonSerializer.Deserialize<Booking>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.POST, RequestLauncher.CONTROLLER.Booking, totalPrice.ToString(), JsonSerializer.Serialize(preBooking)));
            }
            catch (APIExeption e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static List<Booking> PostBookings(List<PreBooking> preBookings, string firstName, string lastName, double totalPrice)
        {
            try
            {
                return JsonSerializer.Deserialize<List<Booking>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.POST, RequestLauncher.CONTROLLER.Booking, "Multiple/" + firstName + "/" + lastName + "/" + totalPrice, JsonSerializer.Serialize(preBookings)));
            }
            catch (APIExeption e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public static bool CheckFlightLimit(int flightId, DateTime date)
        {
            try
            {
                return JsonSerializer.Deserialize<bool>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Booking, "checkFlightLimit/" + flightId.ToString() + "/" + date.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")));
            }
            catch (APIExeption e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Bills
        /// </summary>
        public static double GetPrice(PreBooking bill)
        {
            try
            {
                return JsonSerializer.Deserialize<double>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.PUT, RequestLauncher.CONTROLLER.PreBooking, "price", JsonSerializer.Serialize(bill)));
            }
            catch (APIExeption e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
        public static double GetCartPrice(List<PreBooking> bills)
        {
            try
            {
                return JsonSerializer.Deserialize<double>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.PUT, RequestLauncher.CONTROLLER.PreBooking, "cartprice", JsonSerializer.Serialize(bills)));
            }
            catch (APIExeption e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
        public static Dictionary<MoneyRef, double> PriceConverted()
        {
            try
            {
                return JsonSerializer.Deserialize<Dictionary<MoneyRef, double>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.PreBooking, "convert"));
            }
            catch (APIExeption e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Transactions
        /// </summary>
        public static List<Transaction> GetTransactions()
        {
            try
            {
                return JsonSerializer.Deserialize<List<Transaction>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Transaction, string.Empty));
            }
            catch (APIExeption e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public static Transaction PostTransaction(Transaction transaction)
        {
            try
            {
                return JsonSerializer.Deserialize<Transaction>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.POST, RequestLauncher.CONTROLLER.Transaction, string.Empty, JsonSerializer.Serialize(transaction)));
            }
            catch (APIExeption e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// External Flights
        /// </summary>
        /// <returns></returns>
        public static List<Flight> GetExtFlights()
        {
            List<ExternalFlight> loef = JsonSerializer.Deserialize<List<ExternalFlight>>(ExternalRequestLauncher.GetFlights(""));
            return FlightParser.fullconversion(loef);
        }
        public static List<Flight> GetAllFlights()
        {
            List<Flight> localFlights = GetFlights();
            foreach (Flight item in GetExtFlights())
            {
                localFlights.Add(item);
            }
            return localFlights;
        }
    }
}
