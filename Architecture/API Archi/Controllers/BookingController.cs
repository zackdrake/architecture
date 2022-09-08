using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace API_Archi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;

        public BookingController(ILogger<BookingController> logger)
        {
            _logger = logger;
        }

        // http://localhost:52880/Booking/
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            string fileName = "Booking.json";
            string jsonString = System.IO.File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<Booking[]>(jsonString);
        }

        // http://localhost:52880/Booking/
        [HttpPost]
        public void Post(Booking booking)
        {
            string fileName = "Booking.json";
            string jsonString = JsonSerializer.Serialize(booking);
            System.IO.File.WriteAllText(fileName, jsonString);
        }

        // http://localhost:52880/Booking/checkFlightLimit/{id}/{date}
        [HttpGet("checkFlightLimit/{id}/{date}")]
        public bool CheckFlightLimit(int id, DateTime date)
        {
            string fileName = "Booking.json";
            string jsonString = System.IO.File.ReadAllText(fileName);
            Booking[] bookings = JsonSerializer.Deserialize<Booking[]>(jsonString);

            Flight[] flights = FlightController.FlightTab;
            int limit = 0;

            foreach(Flight flight in flights)
            {
                if (flight.id == id) limit = flight.nbMaxPlaces;
            }

            int limitTrigger = 0;

            foreach(Booking booking in bookings)
            {
                if (booking.FlightId == id && booking.date == date) 
                {
                    limitTrigger++;
                }
            }

            if (limitTrigger < limit)
            {
                return true;
            }
            return false;
        }
    }
}
