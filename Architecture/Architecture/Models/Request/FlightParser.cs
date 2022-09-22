using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using API_Archi;
using System.Text.Json;

namespace Architecture.Models.Request
{
    public class FlightParser{
        public static Flight conversion(ExternalFlight extFlight){
            Random rnd = new Random();
            return new Flight(
                rnd.Next(1000), 
                extFlight.departure,
                extFlight.arrival,
                extFlight.base_price,
                extFlight.plane.total_seats);
        }
        
        public static List<Flight> fullconversion(List<ExternalFlight> listExtFlight){
            List<Flight> result = new List<Flight>();
            foreach (ExternalFlight item in listExtFlight)
            {
                result.Add(conversion(item));
            }
            return result;
        }

        
    }

}
