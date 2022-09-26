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
            return new Flight(
                extFlight.code,
                extFlight.departure,
                extFlight.arrival,
                null,
                extFlight.base_price,
                extFlight.plane.total_seats,
                Flight.Type.Flight,
                Flight.Source.external);
        }
        
        public static List<Flight> fullconversion(List<ExternalFlight> listExtFlight){
            List<Flight> result = new List<Flight>();
            foreach (ExternalFlight item in listExtFlight)
            {
                result.Add(conversion(item));
            }
            return result;
        }

        public static Flight group7Conversion(Group7Flight g7Flight){
            return new Flight(
                g7Flight.id.ToString(),
                g7Flight.departure,
                g7Flight.arrival,
                null,
                g7Flight.price,
                -1,
                Flight.Type.Flight,
                Flight.Source.external);
        }

        public static List<Flight> group7fullconversion(List<Group7Flight> listExtFlight){
            List<Flight> result = new List<Flight>();
            foreach (Group7Flight item in listExtFlight)
            {
                result.Add(group7Conversion(item));
            }
            return result;
        }

        public static BrokerFlight flightToBroker(Flight flight){

            return new BrokerFlight(
                null,
                flight.airport_start,
                flight.airport_arrival,
                flight.id,
                flight.GetFlightOptions(),
                flight.StopAirPorts(),
                flight.nb_max_places,
                flight.price);
        }

        public static Flight brokerToFlight(BrokerFlight brokerFlight){
            return new Flight(
                brokerFlight.internal_code,
                brokerFlight.departure,
                brokerFlight.arrival,
                null,
                brokerFlight.price,
                brokerFlight.total_seats,
                Flight.Type.Flight,
                Flight.Source.broker);
        }
        
    }

}
