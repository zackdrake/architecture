using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API_Archi.External
{
    public class RequestExternalLauncher
    {
        public static string EXTERNAL_API_URL = "https://api-6yfe7nq4sq-uc.a.run.app";
        public enum METHOD
        {
            GET,
            POST
        }

        public enum ENDPOINT
        {
            flights,
            available_options,
            book
        }

        public static string SendExternalRequest(METHOD method, ENDPOINT endpoint, string parameters)
        {
            string result = string.Empty;
            string url = EXTERNAL_API_URL + "/" + endpoint.ToString();
            if (!string.IsNullOrEmpty(parameters)) {
                url += "/" + parameters;
            }

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

        public static string GetFlights(string date)
        {
            return SendExternalRequest(METHOD.GET, ENDPOINT.flights, date);
        }

        public static string GetAvailableOptions(string flightCode)
        {
            return SendExternalRequest(METHOD.GET, ENDPOINT.available_options, flightCode);
        }
    }
}
