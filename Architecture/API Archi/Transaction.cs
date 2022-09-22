using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Archi
{
    public class Transaction
    {
        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public double transactionPrice { get; set; }

        public Transaction(int id, string firstName, string lastName, double transactionPrice)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.transactionPrice = transactionPrice;
        }
    }
}
