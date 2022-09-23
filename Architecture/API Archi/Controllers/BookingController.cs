using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace API_Archi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private static string FileName = "Tables/Booking.json";

        private static List<Booking> ReadBookingContext()
        {
            string jsonString = System.IO.File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<List<Booking>>(jsonString);
        }

        private static void WriteBookingContext(List<Booking> bookings)
        {
            string jsonString = JsonSerializer.Serialize(bookings);
            System.IO.File.WriteAllText(FileName, jsonString);
        }

        private static int NewBookingId()
        {
            List<Booking> bookings = ReadBookingContext();

            if (bookings.Count() > 0)
            {
                return bookings.Last().id + 1;
            }
            return 0;
        }

        // http://localhost:52880/Booking/
        [HttpGet]
        public List<Booking> Get()
        {
            List<Booking> bookings = ReadBookingContext();

            if (bookings.Count > 0)
            {
                return bookings;
            }
            throw new APIExeption(APIExeption.ExeptionType.ObjectNotFound);
        }

        // http://localhost:52880/Booking/
        [HttpPost("{totalPrice}")]
        public Booking Post(PreBooking preBooking, double totalPrice)
        {
            List<Booking> bookings = ReadBookingContext();
            Flight flight = new FlightController().GetFlightById(preBooking.FlightId);

            if (CheckFlightLimit(preBooking.FlightId, preBooking.date))
            {
                Transaction transaction = new Transaction(TransactionController.NewTransactionId(), preBooking.firstName, preBooking.lastName, totalPrice);
                new TransactionController().Post(transaction);

                Booking booking = new Booking(NewBookingId(), flight.price, FlightController.luggagePrice, FlightController.childReduction, transaction.id, preBooking);

                bookings.Add(booking);
                WriteBookingContext(bookings);

                return booking;
            }
            throw new APIExeption(APIExeption.ExeptionType.FlightFull);
        }

        // http://localhost:52880/Booking/Multiple/Billy/Elliot/500
        [HttpPost("Multiple/{firstName}/{lastName}/{totalPrice}")]
        public List<Booking> PostMultiple(List<PreBooking> preBookings, string firstName, string lastName, double totalPrice)
        {
            Transaction transaction = new Transaction(TransactionController.NewTransactionId(), firstName, lastName, totalPrice);
            new TransactionController().Post(transaction);

            List<Booking> bookings = new List<Booking>();

            foreach (PreBooking booking in preBookings)
            {
                Booking newBooking = NoneHttpPost(booking, transaction);
                if (newBooking != null)
                {
                    bookings.Add(newBooking);
                }
            }
            if (bookings.Count > 0)
            {
                return bookings;
            }
            throw new APIExeption(APIExeption.ExeptionType.FlightFull);
        }

        private Booking NoneHttpPost(PreBooking preBooking, Transaction transaction)
        {
            if (CheckFlightLimit(preBooking.FlightId, preBooking.date))
            {
                List<Booking> bookings = ReadBookingContext();
                List<Flight> flights = FlightController.ReadFlightContext();
                Flight flight = flights.Single(fl => fl.id == preBooking.FlightId);

                Booking booking = new Booking(NewBookingId(), flight.price, FlightController.luggagePrice, FlightController.childReduction, transaction.id, preBooking);

                bookings.Add(booking);
                WriteBookingContext(bookings);

                return booking;
            }
            return null;
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
