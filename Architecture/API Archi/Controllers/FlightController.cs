using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace API_Archi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        public static readonly Flight[] FlightTab = new Flight[]
        {
            new Flight(0, "CDG", "JFK", 1000, 750),
            new Flight(1, "JFK", "CDG", 1000, 750),
            new Flight(2, "CDG", "DTW", 700, 500),
            new Flight(3, "DTW", "CDG", 700, 500),
            new Flight(4, "JFK", "DTW", 300, 250),
            new Flight(5, "DTW", "JFK", 300, 250)
        };

        private readonly ILogger<FlightController> _logger;

        public FlightController(ILogger<FlightController> logger)
        {
            _logger = logger;
        }

        // http://localhost:52880/Flight/
        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return FlightTab;
        }

        // http://localhost:52880/Flight/discount/{id}
        [HttpGet("discount/{id}")]
        public double Discount(int id)
        {
            double price = 0;

            Flight[] flights = FlightTab;
            foreach (Flight flight in flights)
            {
                if (flight.id == id)
                {
                    price = flight.price * 0.9;
                }
            }
            return price;
        }
    }
}
