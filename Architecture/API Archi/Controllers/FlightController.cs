using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return FlightTab;
        }
    }
}
