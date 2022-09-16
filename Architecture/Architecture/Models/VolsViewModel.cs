using API_Archi;
using System.Collections.Generic;

namespace Architecture.Models
{
    public class VolsViewModel
    {
        private List<Flight> _Flights;
        private List<Booking> _Bookings;
        public VolsViewModel(List<Flight> flights)
        {
            _Flights = flights;
        }
        public VolsViewModel(List<Booking> bookings)
        {
            Bookings = bookings;
        }

        public List<Flight> Flights => _Flights;

        public List<Booking> Bookings { get => _Bookings; set => _Bookings = value; }
    }

}
