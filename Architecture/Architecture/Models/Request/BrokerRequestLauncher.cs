using API_Archi;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Models.Request
{

    public class BrokerRequestLauncher
    {

        public static string Broker_API_URL = "http://server.aurelientorres.com";
        public static string Broker_API_KEY = "8319768420";
        public enum METHOD
        {
            GET,
            POST
        }

        public enum ENDPOINT
        {
            flights,
            booking
        }

        public static string SendBrokerRequest(METHOD method, ENDPOINT endpoint)
        {
            string result = string.Empty;
            string url = Broker_API_URL + "/" + endpoint.ToString();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Method = method.ToString();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }


        public static string SendBrokerRequest(METHOD method, ENDPOINT endpoint, string jsonBody)
        {
            string result = string.Empty;
            string url = Broker_API_URL + "/" + endpoint.ToString();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Method = method.ToString();

            byte[] postBytes = Encoding.UTF8.GetBytes(jsonBody);
            request.ContentType = "application/json; charset=UTF-8";
            request.Accept = "application/json";
            request.ContentLength = postBytes.Length;

            Stream requestStream = request.GetRequestStream();
            try
            {
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                HttpStatusCode statusCode = response.StatusCode;
                using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
                {
                    result = rdr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new HttpListenerException(e.GetHashCode(), e.Message);
            }

            return result;

        }

        public static string GetFlights()
        {
            return SendBrokerRequest(METHOD.GET, ENDPOINT.flights);
        }

        public static string PostFlights(List<Flight> internalFlights)
        {
            List<BrokerFlight> convertedInternalFlights = FlightParser.flightToBrokerFullConversion(internalFlights);
            BrokerFlightSender brokerFlightSender = new BrokerFlightSender(Broker_API_KEY,convertedInternalFlights);
            return SendBrokerRequest(METHOD.POST, ENDPOINT.flights, JsonSerializer.Serialize(brokerFlightSender));
        }


        public static string PostBooking(BrokerBooking BrokerBooking)
        {
            return SendBrokerRequest(METHOD.POST, ENDPOINT.booking, JsonSerializer.Serialize(BrokerBooking)); //TODO
        }
    }
}