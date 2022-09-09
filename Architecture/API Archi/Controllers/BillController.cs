using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Archi.Controllers
{
    public class BillController : ControllerBase
    {
        // http://localhost:52880/Bill/price
        [HttpGet("price")]
        public double Price(Bill bill)
        {
            double price = 0;

            List<Flight> flights = FlightController.ReadFlightContext();

            Flight flight = flights.Single(fl => fl.id == bill.flightId);

            price = flight.price;

            if (bill.discount) { price *= 0.9; }
            if (bill.option) { price += 50; }

            return price;
        }

        // http://localhost:52880/Bill/cartprice
        [HttpGet("cartprice")]
        public double CartPrice(List<Bill> bills)
        {
            double price = 0;

            foreach(Bill bill in bills)
            {
                price += Price(bill);
            }

            return price;
        }
    }
}
