using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API_Archi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : Controller
    {
        public static double luggagePrice = 50;
        public static double childReduction = 0.9;
        public static List<Flight> ReadFlightContext()
        {
            List<Flight> flightContext = new List<Flight>();

            flightContext.Add(new Flight(0, "CDG", "JFK", null, 1000, 750, Flight.Type.Flight, Flight.Source.intern));
            flightContext.Add(new Flight(1, "JFK", "CDG", null, 1000, 750, Flight.Type.Flight, Flight.Source.intern));
            flightContext.Add(new Flight(2, "CDG", "DTW", null, 700, 500, Flight.Type.Flight, Flight.Source.intern));
            flightContext.Add(new Flight(3, "DTW", "CDG", null, 700, 500, Flight.Type.Flight, Flight.Source.intern));
            flightContext.Add(new Flight(4, "JFK", "DTW", null, 300, 250, Flight.Type.Flight, Flight.Source.intern));
            flightContext.Add(new Flight(5, "DTW", "JFK", null, 300, 250, Flight.Type.Flight, Flight.Source.intern));
            flightContext.Add(new Flight(6, "CDG", "DTW", flightContext[5], 1000, 200, Flight.Type.Flight, Flight.Source.intern));
            flightContext.Add(new Flight(7, "JFK", "DTW", flightContext[3], 1000, 200, Flight.Type.Flight, Flight.Source.intern));
            flightContext.Add(new Flight(8, "JFK", "ORD", null, 400, 600, Flight.Type.Flight, Flight.Source.intern));
            flightContext.Add(new Flight(9, "CDG", "EWR", new Flight(10, "EWR", "JFK", flightContext[8], 30, 600, Flight.Type.Train, Flight.Source.intern), 400, 600, Flight.Type.Flight, Flight.Source.intern));

            return flightContext;
        }

        // http://localhost:52880/Flight/
        [HttpGet]
        public List<Flight> Get()
        {
            List<Flight> flights = ReadFlightContext();
            
            if(flights.Count > 0)
            {
                return flights;
            }
            throw new APIExeption(APIExeption.ExeptionType.ObjectNotFound);
        }

        public Flight GetFlightById(int id)
        {
            Flight flight = ReadFlightContext().Single(fl => fl.id == id);

            if (flight != null)
            {
                return flight;
            }
            throw new APIExeption(APIExeption.ExeptionType.ObjectNotFound);
        }
    }
}