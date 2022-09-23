using API_Archi;
using System;
using System.Collections.Generic;
using System.Text.Json;
using static API_Archi.Controllers.BillController;

namespace Architecture.Models.Request
{
    public class RequestCenter
    {
        /// <summary>
        /// Flights
        /// </summary>
        public static List<Flight> GetFlights() => JsonSerializer.Deserialize<List<Flight>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Flight, null));

        /// <summary>
        /// Bookings
        /// </summary>
        public static List<Booking> GetBookings() => JsonSerializer.Deserialize<List<Booking>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Booking, string.Empty));
        public static Booking PostBooking(PreBooking preBooking, double totalPrice) => JsonSerializer.Deserialize<Booking>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.POST, RequestLauncher.CONTROLLER.Booking, totalPrice.ToString(), JsonSerializer.Serialize(preBooking)));
        public static List<PreBooking> PostBookings(List<PreBooking> preBookings, string firstName, string lastName, double totalPrice) => JsonSerializer.Deserialize<List<PreBooking>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.POST, RequestLauncher.CONTROLLER.Booking, "Multiple/" + firstName + "/" + lastName + "/" + totalPrice, JsonSerializer.Serialize(preBookings)));
        public static bool CheckFlightLimit(int flightId, DateTime date) => JsonSerializer.Deserialize<bool>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Booking, "checkFlightLimit/" + flightId.ToString() + " / " + date.ToString("dd'-'mm'-'YY'T'HH':'mm':'ss")));

        /// <summary>
        /// Bills
        /// </summary>
        public static double GetPrice(Bill bill) => JsonSerializer.Deserialize<double>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Bill, "price", JsonSerializer.Serialize(bill)));
        public static double GetCartPrice(List<Bill> bills) => JsonSerializer.Deserialize<double>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Bill, "cartprice", JsonSerializer.Serialize(bills)));
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
            try {
                List<ExternalFlight> loef = JsonSerializer.Deserialize<List<ExternalFlight>>(ExternalRequestLauncher.GetFlights(""));
                return FlightParser.fullconversion(loef);
            }
            catch {
                return new List<Flight>();
            }
        }
        public static List<Flight> GetGroup7Flights() {
            try{
                List<Group7Flight> log7f = JsonSerializer.Deserialize<List<Group7Flight>>(Group7RequestLauncher.GetFlights());
                return FlightParser.group7fullconversion(log7f);
            }
            catch {
                return new List<Flight>();
            }
        }
        public static List<Flight> GetAllFlights() {
            List<Flight> localFlights = GetFlights();
            foreach(Flight item in GetExtFlights()){
                localFlights.Add(item);
            }
            foreach(Flight item in GetGroup7Flights()){
                localFlights.Add(item);
            }
            return localFlights;
        }
    }
}
