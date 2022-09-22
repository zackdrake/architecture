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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new VolsViewModel(RequestCenter.GetAllFlights());
            return View(model);
        }

        [HttpPost]
        public IActionResult IndexPost(int flight, bool Child, bool Bagage, string Name, string Surname, DateTime Date)
        {
            var booking = new PreBooking(Surname, Name, flight, Date, Bagage, Child);
            Booking bookingTest = RequestCenter.PostBooking(booking, 0); // IL MANQUE LE PRIX DONNÉ PAR LE SERVEUR AU MOMENT DE LA TRANSACTION
            return Redirect("Index");
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
