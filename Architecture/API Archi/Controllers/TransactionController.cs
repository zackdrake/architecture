using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace API_Archi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private static string FileName = "Tables/Transaction.json";

        private static List<Transaction> ReadTransactionContext()
        {
            string jsonString = System.IO.File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<List<Transaction>>(jsonString);
        }

        private static void WriteTransactionContext(List<Transaction> bookings)
        {
            string jsonString = JsonSerializer.Serialize(bookings);
            System.IO.File.WriteAllText(FileName, jsonString);
        }

        internal static int NewTransactionId()
        {
            List<Transaction> transactions = ReadTransactionContext();

            if (transactions.Count() > 0)
            {
                return transactions.Last().id + 1;
            }
            return 0;
        }

        // http://localhost:52880/Transaction/
        [HttpGet]
        public List<Transaction> Get()
        {
            List<Transaction> transactions = ReadTransactionContext();

            if (transactions.Count > 0)
            {
                return transactions;
            }
            throw new APIExeption(APIExeption.ExeptionType.ObjectNotFound);
        }

        // http://localhost:52880/Transaction/
        [HttpPost]
        public Transaction Post(Transaction transaction)
        {
            List<Transaction> transactions = ReadTransactionContext();

            transactions.Add(transaction);

            WriteTransactionContext(transactions);

            return transaction;
        }
    }
}
