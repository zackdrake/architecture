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
        public static List<Flight> GetFlights() => JsonSerializer.Deserialize<List<Flight>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Flight, string.Empty));

        /// <summary>
        /// Bookings
        /// </summary>
        public static List<Booking> GetBookings() => JsonSerializer.Deserialize<List<Booking>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Booking, string.Empty));
        public static Booking PostBooking(PreBooking preBooking, double totalPrice) => JsonSerializer.Deserialize<Booking>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.POST, RequestLauncher.CONTROLLER.Booking, totalPrice.ToString(), JsonSerializer.Serialize(preBooking)));
        public static List<PreBooking> PostBookings(List<PreBooking> preBookings, string firstName, string lastName, double totalPrice) => JsonSerializer.Deserialize<List<PreBooking>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.POST, RequestLauncher.CONTROLLER.Booking, "Multiple/" + firstName + "/" + lastName + "/" + totalPrice, JsonSerializer.Serialize(preBookings)));
        public static bool CheckFlightLimit(int flightId, DateTime date) => JsonSerializer.Deserialize<bool>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Booking, "checkFlightLimit/" + flightId.ToString() + "/" + date.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")));

        /// <summary>
        /// Bills
        /// </summary>
        public static double GetPrice(PreBooking bill) => JsonSerializer.Deserialize<double>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Bill, "price", JsonSerializer.Serialize(bill)));
        public static double GetCartPrice(List<PreBooking> bills) => JsonSerializer.Deserialize<double>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Bill, "cartprice", JsonSerializer.Serialize(bills)));
        public static Dictionary<MoneyRef, double> PriceConverted() => JsonSerializer.Deserialize<Dictionary<MoneyRef, double>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Bill, "convert"));

        /// <summary>
        /// Transactions
        /// </summary>
        public static List<Transaction> GetTransactions() => JsonSerializer.Deserialize<List<Transaction>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Transaction, string.Empty));
        public static Transaction PostTransaction(Transaction transaction) => JsonSerializer.Deserialize<Transaction>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.POST, RequestLauncher.CONTROLLER.Transaction, string.Empty, JsonSerializer.Serialize(transaction)));
        
        /// <summary>
        /// External Flights
        /// </summary>
        /// <returns></returns>
        public static List<Flight> GetExtFlights() {
            List<ExternalFlight> loef = JsonSerializer.Deserialize<List<ExternalFlight>>(ExternalRequestLauncher.GetFlights(""));
            return FlightParser.fullconversion(loef);
        }
        public static List<Flight> GetAllFlights() {
            List<Flight> localFlights = GetFlights();
            foreach(Flight item in GetExtFlights()){
                localFlights.Add(item);
            }
            return localFlights;
        }
    }
}
