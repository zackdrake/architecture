using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace API_Archi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalFlightController : ControllerBase
    {
        EXTERNAL_API_URL = "https://api-6yfe7nq4sq-uc.a.run.app"


        public List<Flight> ReadExternalFlightContext()
        {
            List<Flight> flightContext = new List<Flight>();
            

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

        // http://localhost:52880/Flight/discount/{id}
        [HttpGet("discount/{id}")]
        public double Discount(int id)
        {
            double price = 0;

            List<Flight> flights = ReadFlightContext();
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
