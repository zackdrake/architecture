using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Models.Request
{
    public class Group7RequestLauncher
    {
        public static string EXTERNAL_API_URL = "http://10.8.110.211:8080";
        public static string GROUP7_API_KEY = "eyJjbGllbnRJZCI6ICJkanVzdC1rZXkiLCJhcGlLZXkiOiAiZGp1c3Qta2V5In0";
        public enum METHOD
        {
            GET,
            POST
        }

        public enum ENDPOINT
        {
            flight,
            booking,
        }

        public static string SendGroup7Request(METHOD method, ENDPOINT endpoint, string parameters)
        {
            string result = string.Empty;
            string url = EXTERNAL_API_URL + "/" + endpoint.ToString();
            if (!string.IsNullOrEmpty(parameters)) {
                url += "/" + parameters;
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("su-api-key", GROUP7_API_KEY);
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

        public static string GetFlights()
        {
            return SendGroup7Request(METHOD.GET, ENDPOINT.flight, null);
        }

        public static string GetAirports()
        {
            return SendGroup7Request(METHOD.GET, ENDPOINT.flight, "airports");
        }

        public static string GetBooking(int flightId, int age, bool hasLuggage, bool hasGroupPrize)
        {
            return SendGroup7Request(METHOD.GET, ENDPOINT.booking, "/price/"+flightId+"?age="+age+"&luggage="+hasLuggage+"&groupPrice="+hasGroupPrize);
        }

    }
}
