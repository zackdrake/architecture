using API_Archi;
using System.Collections.Generic;
using System.Text.Json;

namespace Architecture.Models
{
    public class TransactionModel
    {
        private List<PreBooking> _Bookings;
        private double _Price;
        private string _jsonStringBookings;

        public TransactionModel(List<PreBooking> bookings, double price)
        {
            Bookings = bookings;
            Price = price;
            JsonStringBookings = JsonSerializer.Serialize(bookings);
        }

        public List<PreBooking> Bookings { get => _Bookings; set => _Bookings = value; }
        public double Price { get => _Price; set => _Price = value; }
        public string JsonStringBookings { get => _jsonStringBookings; set => _jsonStringBookings = value; }
    }

}
