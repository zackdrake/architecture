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

        public double baseBilletPrice { get; set; }

        public double luggage { get; set; }

        public double childReduction { get; set; }

        public int transactionId { get; set; }

        public Booking(int id, string firstName, string lastName, int FlightId, DateTime date, double baseBilletPrice, double luggage, double childReduction, int transactionId)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.FlightId = FlightId;
            this.date = date;
            this.baseBilletPrice = baseBilletPrice;
            this.luggage = luggage;
            this.childReduction = childReduction;
            this.transactionId = transactionId;
        }

        public Booking(int id, int price, double luggagePrice, double childReduction, int transactionId, PreBooking preBooking)
        {
            this.id = id;
            firstName = preBooking.firstName;
            lastName = preBooking.lastName;
            FlightId = preBooking.FlightId;
            date = preBooking.date;
            baseBilletPrice = price;
            luggage = luggagePrice;
            this.childReduction = childReduction;
            this.transactionId = transactionId;
        }
    }
}
