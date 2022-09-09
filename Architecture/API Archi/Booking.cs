using System;

namespace API_Archi
{
    public class Booking
    {
        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int FlightId { get; set; }

        public DateTime date { get; set; }

        public Booking(int id, string firstName, string lastName, int FlightId, DateTime date)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.FlightId = FlightId;
            this.date = date;
        }
    }
}
