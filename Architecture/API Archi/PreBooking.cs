using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Archi
{
    public class PreBooking
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string FlightId { get; set; }

        public DateTime date { get; set; }

        public bool luggage { get; set; }

        public bool childReduction { get; set; }

        public bool trainFirstClassOption { get; set; }

        public PreBooking(string firstName, string lastName, string FlightId, DateTime date, bool luggage, bool childReduction, bool trainFirstClassOption)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.FlightId = FlightId;
            this.date = date;
            this.luggage = luggage;
            this.childReduction = childReduction;
            this.trainFirstClassOption = trainFirstClassOption;
        }
    }
}
