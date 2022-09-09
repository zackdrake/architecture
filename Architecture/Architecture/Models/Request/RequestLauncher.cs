using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Models.Request
{
    public class RequestLauncher
    {
        public static string HTTP = @"http://localhost:52880/";
        public enum METHOD
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public enum CONTROLLER
        {
            Booking,
            Flight
        }

        public static string LaunchRequest(METHOD method, CONTROLLER controller, string _url)
        {
            string result = string.Empty;
            string url = HTTP + controller.ToString() + "/" + _url;

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

        public static string LaunchRequest(METHOD method, CONTROLLER controller, string _url, string json)
        {
            string url = HTTP + controller.ToString() + "/" + _url;

            byte[] dataBytes = Encoding.UTF8.GetBytes(json);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.Method = method.ToString();

            using (Stream requestBody = request.GetRequestStream())
            {
                requestBody.Write(dataBytes, 0, dataBytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
