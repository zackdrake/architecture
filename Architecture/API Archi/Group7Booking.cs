using System;

namespace API_Archi
{
    public class Group7Booking
    {
        public DateTime date { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public int age { get; set; }

        public string currency { get; set; }

        public Group7Booking(DateTime date, string firstname, string lastname, int age, string currency)
        {
            this.date = date;
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
            this.currency = currency;
        }
    }
}