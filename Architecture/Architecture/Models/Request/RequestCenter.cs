using API_Archi;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Architecture.Models.Request
{
    public class RequestCenter
    {
        public static List<Flight> GetFlights() => JsonSerializer.Deserialize<List<Flight>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Flight, string.Empty));
        public static List<Flight> GetDiscounts(int flightId) => JsonSerializer.Deserialize<List<Flight>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Flight, flightId.ToString()));
        public static List<Booking> PostBooking(Booking booking) => JsonSerializer.Deserialize<List<Booking>>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.POST, RequestLauncher.CONTROLLER.Booking, string.Empty, JsonSerializer.Serialize(booking)));
        public static bool CheckFlightLimit(int flightId, DateTime date) => JsonSerializer.Deserialize<bool>(RequestLauncher.LaunchRequest(RequestLauncher.METHOD.GET, RequestLauncher.CONTROLLER.Booking, flightId.ToString() + "/" + date.ToString("dd'-'mm'-'YY'T'HH':'mm':'ss")));
    }
}
