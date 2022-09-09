using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API_Archi.External
{
    public class ExternalRequestLauncher
    {
        public static string EXTERNAL_API_URL = "https://api-6yfe7nq4sq-uc.a.run.app";
        public enum METHOD
        {
            GET,
            POST
        }

        public enum Endpoints
        {
            flights,
            available-options,
            book
        }

        public static string GetFlights(METHOD method, ENDPOINT endpoint, string date)
        {
            string result = string.Empty;
            if string.date.IsNullorEmpty(){
                string url = EXTERNAL_API_URL + "/" + endpoint.ToString();
            } else {
                string url = EXTERNAL_API_URL + "/" + endpoint.ToString() + "/" + date;
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


        // public static string LaunchRequest(METHOD method, CONTROLLER controller, string _url, string json)
        // {
        //     string url = HTTP + controller.ToString() + "/" + _url;

        //     byte[] dataBytes = Encoding.UTF8.GetBytes(json);

        //     HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //     request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
        //     request.ContentLength = dataBytes.Length;
        //     request.Method = method.ToString();

        //     using (Stream requestBody = request.GetRequestStream())
        //     {
        //         requestBody.Write(dataBytes, 0, dataBytes.Length);
        //     }

        //     using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //     using (Stream stream = response.GetResponseStream())
        //     using (StreamReader reader = new StreamReader(stream))
        //     {
        //         return reader.ReadToEnd();
        //     }
        // }
    }
}
