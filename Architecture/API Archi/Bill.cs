using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Archi
{
    public class Bill
    {
        public int flightId { get; set; }
        public bool luggage { get; set; }
        public bool childReduce { get; set; }

        public Bill(int flightId, bool discount, bool option)
        {
            this.flightId = flightId;
            this.luggage = discount;
            this.childReduce = option;
        }
    }
}
