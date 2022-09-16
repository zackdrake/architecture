using API_Archi;
using Architecture.Models;
using Architecture.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Architecture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Booking> _Bookings;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new VolsViewModel(RequestCenter.GetFlights());
            return View(model);
        }

        [HttpPost]
        public IActionResult IndexPost(int flight, bool Child, bool Bagage, string FirstName, string LastName, DateTime Date, string submit)
        {
            if (submit == "transaction")
            {
                var booking = new Booking(0, FirstName, LastName, flight, Date);
                if (_Bookings == null)
                    _Bookings = new List<Booking>();
                _Bookings.Add(booking);
                return Transaction();
            }
            else
            {
                var booking = new Booking(0, FirstName, LastName, flight, Date);
                Booking bookingTest = RequestCenter.PostBooking(booking);
                return Redirect("Index");
            }
        }

        public IActionResult Transaction()
        {
            if(_Bookings == null)
            {
                _Bookings = new List<Booking>();
            }
            var model = new VolsViewModel(_Bookings);
            return View("Transaction",model);
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
