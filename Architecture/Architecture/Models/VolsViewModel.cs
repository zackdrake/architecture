using System;
using System.Collections.Generic;

namespace Architecture.Models
{
    public class VolsViewModel
    {
        private List<Flight> _Flights;
        public VolsViewModel(List<Flight> flights)
        {
            _Flights = flights;
        }

        public List<Flight> Flights { get => _Flights; set => _Flights = value; }
    }

}
