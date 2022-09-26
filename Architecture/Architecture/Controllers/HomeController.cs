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
            Console.WriteLine(RequestCenter.PostFlights());
            var model = new VolsViewModel(RequestCenter.GetAllFlights());

            if (bookings != null){
                model.Bookings = bookings;
                model.JsonStringBookings = JsonSerializer.Serialize(bookings);
            }
            return View("Index",model);
        }

        [HttpPost]
        public IActionResult IndexPost(string flightSourceId, string FirstName, string LastName, DateTime Date, bool Child, bool Luggage, bool FirstClass, bool ChampagneOnBoard, bool LoungeAccess, string bookings, string submit)
        {
            string flight = flightSourceId.Split("_")[0];
            string source = flightSourceId.Split("_")[1];

            if (source == "intern")
            {
                // create list PreBooking
                List<PreBooking> bookingslist = new List<PreBooking>();
                if (bookings != null)
                {
                    bookingslist = JsonSerializer.Deserialize<List<PreBooking>>(bookings);
                }

                // check flight 
                if (RequestCenter.CheckFlightLimit(flight, Date))
                {
                    PreBooking booking = new PreBooking(FirstName, LastName, flight, Date, Luggage, Child, false);
                    bookingslist.Add(booking);

                }
                else
                {
                    if (submit == "payer")
                    {
                        return Index(bookingslist);
                    }
                }

                // continue transaction or cell flights 
                if (submit == "transaction")
                {
                    return Index(bookingslist);
                }
                else
                {

                    double price = RequestCenter.GetCartPrice(bookingslist);
                    return Transaction(bookingslist, price);
                }
            }
            else if(source == "external")
            {
                string externalDate = Date.ToString("dd'-'MM'-'yyyy");


                ExternalFlight externalFlight = null;

                try
                {
                    List<ExternalFlight> loef = JsonSerializer.Deserialize<List<ExternalFlight>>(ExternalRequestLauncher.GetFlights(""));

                    foreach(ExternalFlight external in loef)
                    {
                        if (external.code == flight)
                        {
                            externalFlight = external;
                            break;
                        }
                    }
                }
                catch { }

                string listoptionJson = ExternalRequestLauncher.GetAvailableOptions(flight);
                var tabOptions = JsonSerializer.Deserialize<ExternalFlightOptions[]>(listoptionJson);

                //ExternalFlightOptions optionsLuggage = new ExternalFlightOptions(OptionType.BonusLuggage, listOption.Find();
                //ExternalFlightOptions optionsChampagneOnBoard = new ExternalFlightOptions(OptionType.ChampagneOnBoard, );
                //ExternalFlightOptions optionsFirstClass = new ExternalFlightOptions(OptionType.FirstClass, );
                //ExternalFlightOptions optionsLoungeAccess = new ExternalFlightOptions(OptionType.LoungeAccess, );

                //ExternalFlightOptions[] options = { optionsLuggage, optionsChampagneOnBoard, optionsFirstClass, optionsLoungeAccess };

                ExternalBooking externalBooking = new ExternalBooking(null, externalFlight, externalDate, externalFlight.base_price, LastName, FirstName, tabOptions, "groupe1");
                
            }
            return Index();
        }

        public IActionResult Transaction(List<PreBooking> bookings, double price)
        {
            TransactionModel model = new TransactionModel(bookings, price);
            return View("Transaction", model);
        }

        public IActionResult TransactionPost(string CustomerFirstName, string CustomerLastName, string bookings, double price)
        {
            // create list PreBooking
            List<PreBooking> bookingslist = new List<PreBooking>();
            if (bookings != null)
            {
                bookingslist = JsonSerializer.Deserialize<List<PreBooking>>(bookings);
            }
            RequestCenter.PostBookings(bookingslist, CustomerFirstName, CustomerLastName, price);
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
