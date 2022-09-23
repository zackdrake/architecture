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
    public class ExternalRequestLauncher
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


        public static string SendExternalRequest(METHOD method, ENDPOINT endpoint, string parameters, string jsonBody)
        {
            string result = string.Empty;
            string url = EXTERNAL_API_URL + "/" + endpoint.ToString();
            if (!string.IsNullOrEmpty(parameters)) {
                url += "/" + parameters;
            }

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

                // grab the response and print it out to the console along with the status code
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

        public static string GetFlights(string date)
        {
            return SendExternalRequest(METHOD.GET, ENDPOINT.flights, date);
        }

        public static string GetAvailableOptions(string flightCode)
        {
            return SendExternalRequest(METHOD.GET, ENDPOINT.available_options, flightCode);
        }

        public static string PostBooking(ExternalBooking externalBooking)
        {
            return SendExternalRequest(METHOD.POST, ENDPOINT.book, null, JsonSerializer.Serialize(externalBooking));
        }
    }
}
