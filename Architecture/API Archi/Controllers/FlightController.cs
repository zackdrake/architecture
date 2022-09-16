using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace API_Archi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {

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

        private readonly ILogger<FlightController> _logger;

        public FlightController(ILogger<FlightController> logger)
        {
            _logger = logger;
        }

        // http://localhost:52880/Flight/
        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return ReadFlightContext();
        }

        // http://localhost:52880/Flight/discount/{discount}/{id}/{option}
        [HttpGet("price/{id}/{discount}/{option}")]
        public double Price(int id, bool discount, bool option)
        {
            double price = 0;

            List<Flight> flights = ReadFlightContext();

            Flight flight = flights.Single(fl => fl.id == id);

            price = flight.price;

            if (discount) { price *= 0.9; }

            if (option) { price += 50; }

            return price;
        }
    }
}

/// STEP 4

/// https://api-6yfe7nq4sq-uc.a.run.app/
/// GET /flights
/// GET /flights/<date>
/// Date: d-m-Y
/// GET /available-options/<flight>
/// POST /book -> Ticket : https://github.com/Sobert/AirTravel/blob/main/src/model.rs
/// Les règles de gestion de base ne s'applique pas