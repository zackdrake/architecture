using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API_Archi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        public static double luggagePrice = 50;
        public static double childReduction = 0.9;
        public static List<Flight> ReadFlightContext()
        {
            List<Flight> flightContext = new List<Flight>();

            flightContext.Add(new Flight(0, "CDG", string.Empty, "JFK", 1000, 750));
            flightContext.Add(new Flight(1, "JFK", string.Empty, "CDG", 1000, 750));
            flightContext.Add(new Flight(2, "CDG", string.Empty, "DTW", 700, 500));
            flightContext.Add(new Flight(3, "DTW", string.Empty, "CDG", 700, 500));
            flightContext.Add(new Flight(4, "JFK", string.Empty, "DTW", 300, 250));
            flightContext.Add(new Flight(5, "DTW", string.Empty, "JFK", 300, 250));
            flightContext.Add(new Flight(6, "CDG", "DTW", "JFK", 1000, 200));
            flightContext.Add(new Flight(7, "JFK", "DTW", "CDG", 1000, 200));

            return flightContext;
        }

        // http://localhost:52880/Flight/
        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return ReadFlightContext();
        }

        public Flight GetFlightById(int id)
        {
            return ReadFlightContext().Single(fl => fl.id == id);
        }
    }
}