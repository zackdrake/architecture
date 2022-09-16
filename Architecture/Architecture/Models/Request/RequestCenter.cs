using API_Archi;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Architecture.Models.Request
{
    public class RequestCenter
    {
        public static List<Flight> GetFlights() => JsonSerializer.Deserialize<List<Flight>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Flight, string.Empty));
        public static List<Flight> GetPrice(int flightId, bool discount, bool option) => JsonSerializer.Deserialize<List<Flight>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Flight, flightId.ToString() + "/" + discount + "/" + option));
        public static List<Booking> PostBooking(Booking booking) => JsonSerializer.Deserialize<List<Booking>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.POST, RequestLauncher.CONTROLLER.Booking, string.Empty, JsonSerializer.Serialize(booking)));
        public static bool CheckFlightLimit(int flightId, DateTime date) => JsonSerializer.Deserialize<bool>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Booking, flightId.ToString() + "/" + date.ToString("dd'-'mm'-'YY'T'HH':'mm':'ss")));
        public static String GetAllExternalFlights() => ExternalRequestLauncher.GetFlights("");
        public static List<ExternalFlight> GetExternalFlights() => JsonSerializer.Deserialize<List<ExternalFlight>>(ExternalRequestLauncher.GetFlights(""));
        //public static List<Flight> GetExtFlights() => FlightParser.fullconversion(JsonSerializer.Deserialize<List<ExternalFlight>>(ExternalRequestLauncher.GetFlights("")));
        // public static List<Flight> GetExtFlights() {
        //     List<Flight> lof = new List<Flight>();
        //     Flight f1 = GetFlights()[0];
        //     lof.Add(f1);
        //     return lof;
        // }
        public static List<Flight> GetExtFlights() {
            List<ExternalFlight> loef = JsonSerializer.Deserialize<List<ExternalFlight>>(ExternalRequestLauncher.GetFlights(""));
            ExternalFlight e1 = loef[0];
            Flight f1 = FlightParser.conversion(e1); 
            List<Flight> lof = new List<Flight>();
            lof.Add(f1);
            return lof;
        }
    }
}
