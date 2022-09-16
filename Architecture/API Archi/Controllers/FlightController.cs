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

            flightContext.Add(new Flight(0, "CDG", "JFK", 1000, 750));
            flightContext.Add(new Flight(1, "JFK", "CDG", 1000, 750));
            flightContext.Add(new Flight(2, "CDG", "DTW", 700, 500));
            flightContext.Add(new Flight(3, "DTW", "CDG", 700, 500));
            flightContext.Add(new Flight(4, "JFK", "DTW", 300, 250));
            flightContext.Add(new Flight(5, "DTW", "JFK", 300, 250));

            return flightContext;
        }

        // http://localhost:52880/Flight/
        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return ReadFlightContext();
        }
    }
}