using API_Archi;
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

        public List<Flight> Flights => _Flights;
    }

}
