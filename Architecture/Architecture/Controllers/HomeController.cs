using API_Archi;
using Architecture.Models;
using Architecture.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace Architecture.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(List<Booking> bookings = null)
        {
            var model = new VolsViewModel(RequestCenter.GetFlights());
            if (bookings != null){
                model.Bookings = bookings;
                model.JsonStringBookings = JsonSerializer.Serialize(bookings);
            }
            return View("Index",model);
        }

        [HttpPost]
        public IActionResult IndexPost(int flight, bool Child, bool Luggage, string FirstName, string LastName, DateTime Date, string bookings, string submit)
        {
            Booking booking = new Booking(0, FirstName, LastName, flight, Date);
            List<Booking> bookingslist = new List<Booking>();
            if (bookings != null)
            {
                bookingslist = JsonSerializer.Deserialize<List<Booking>>(bookings);
            }

            bookingslist.Add(booking);            
            if (submit == "transaction"){
                return Index(bookingslist);
            }
            else {
                return Redirect("Index");
            }
            // if (submit == "transaction")
            // {
            //     var booking = new Booking(0, FirstName, LastName, flight, Date);
            //     if (_Bookings == null)
            //         _Bookings = new List<Booking>();
            //     _Bookings.Add(booking);
            //     return Transaction();
            // }
            // else
            // {
            //     var booking = new Booking(0, FirstName, LastName, flight, Date);
            //     Booking bookingTest = RequestCenter.PostBooking(booking);
            //     return Redirect("Index");
            // }
        }

        // public IActionResult Transaction()
        // {
        //     if(bookings == null)
        //     {
        //         bookings = new List<Booking>();
        //     }
        //     var model = new VolsViewModel(bookings);
        //     return View("Transaction",model);
        // }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
