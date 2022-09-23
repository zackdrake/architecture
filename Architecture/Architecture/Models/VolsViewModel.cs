using API_Archi;
using System.Collections.Generic;
using System.Text.Json;

namespace Architecture.Models
{
    public class VolsViewModel
    {
        private List<Flight> _Flights;
        private List<PreBooking> _Bookings;
        private string _jsonStringBookings;
        public VolsViewModel(List<Flight> flights)
        {
            _Flights = flights;
        }
        public VolsViewModel(List<PreBooking> bookings)
        {
            Bookings = bookings;
        }

        public List<Flight> Flights => _Flights;

        public List<PreBooking> Bookings { get => _Bookings; set => _Bookings = value; }
        public string JsonStringBookings { get => _jsonStringBookings; set => _jsonStringBookings = value; }
    }

}
