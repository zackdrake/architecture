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

        private List<Booking> ReadBookingContext()
        {
            string fileName = "Booking.json";
            string jsonString = System.IO.File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Booking>>(jsonString);
        }

        private void WriteBookingContext(List<Booking> bookings)
        {
            string fileName = "Booking.json";
            string jsonString = JsonSerializer.Serialize(bookings);
            System.IO.File.WriteAllText(fileName, jsonString);
        }

        // http://localhost:52880/Booking/
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            return ReadBookingContext();
        }

        // http://localhost:52880/Booking/
        [HttpPost]
        public void Post(Booking booking)
        {
            List<Booking> bookings = ReadBookingContext();
            bookings.Add(booking);

            WriteBookingContext(bookings);
        }

        // http://localhost:52880/Booking/checkFlightLimit/{id}/{date}
        [HttpGet("checkFlightLimit/{id}/{date}")]
        public bool CheckFlightLimit(int id, DateTime date)
        {
            List<Booking> bookings = ReadBookingContext();

            List<Flight> flights = FlightController.ReadFlightContext();
            int limit = 0;

            foreach(Flight flight in flights)
            {
                if (flight.id == id) limit = flight.nb_max_places;
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
