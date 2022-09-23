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
        public IActionResult Index(List<PreBooking> bookings = null)
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
            PreBooking booking = new PreBooking(FirstName, LastName, flight, Date, Luggage, Child);
            List<PreBooking> bookingslist = new List<PreBooking>();
            if (bookings != null)
            {
                bookingslist = JsonSerializer.Deserialize<List<PreBooking>>(bookings);
            }

            bookingslist.Add(booking);            
            if (submit == "transaction"){
                return Index(bookingslist);
            }
            else {

                RequestCenter.PostBookings(bookingslist);
                return Redirect("Index");
            }
        }

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
