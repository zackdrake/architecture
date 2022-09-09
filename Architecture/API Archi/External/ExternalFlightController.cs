using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace API_Archi.External
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalFlightController : ControllerBase
    {

        // public List<Flight> ReadExternalFlightContext()
        // {
        //     List<Flight> flightContext = new List<Flight>();
            

        //     return flightContext;
        // }

        // private readonly ILogger<ExternalFlightController> _logger;

        // public ExternalFlightController(ILogger<ExternalFlightController> logger)
        // {
        //     _logger = logger;
        // }

        // // http://localhost:52880/Flight/
        // [HttpGet]
        // public IEnumerable<Flight> Get()
        // {
        //     return ReadExternalFlightContext();
        // }

        // // http://localhost:52880/Flight/discount/{id}
        // [HttpGet("discount/{id}")]
        // public double Discount(int id)
        // {
        //     double price = 0;

        //     List<Flight> flights = ReadExternalFlightContext();
        //     foreach (Flight flight in flights)
        //     {
        //         if (flight.id == id)
        //         {
        //             price = flight.price * 0.9;
        //         }
        //     }
        //     return price;
        // }
    }
}
