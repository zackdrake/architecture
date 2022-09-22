using System;

namespace API_Archi
{
    public class ExternalPlane
    {
        public string name { get; set; }

        public int total_seats { get; set; }

        public ExternalPlane(string name, int total_seats)
        {
            this.name = name;
            this.total_seats = total_seats;
        }
    }
}
