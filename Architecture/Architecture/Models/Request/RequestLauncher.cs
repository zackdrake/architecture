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
        public static string HTTP = @"http://localhost:";
        public static string PORT = @"52880/";
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
            Flight,
            Bill,
            Transaction
        }

        public static string LaunchRequest(METHOD method, CONTROLLER controller, string _endPoint)
        {

            string result = string.Empty;
            HttpStatusCode statusCode = 0;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HTTP + PORT + controller + "/" + _endPoint);
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = method.ToString();

            request.ContentType = "application/json; charset=UTF-8";
            request.Accept = "application/json";

            // now send it
            try
            {
                // grab the response and print it out to the console along with the status code
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                statusCode = response.StatusCode;
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

        public static string LaunchRequest(METHOD method, CONTROLLER controller, string _endPoint, string json)
        {
            string strResponseValue = string.Empty;
            HttpStatusCode statusCode = 0;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HTTP + PORT + controller + "/" + _endPoint);
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = method.ToString();

            // turn our request string into a byte stream
            byte[] postBytes = Encoding.UTF8.GetBytes(json);

            request.ContentType = "application/json; charset=UTF-8";
            request.Accept = "application/json";
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();

            // now send it
            try
            {
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                // grab the response and print it out to the console along with the status code
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                statusCode = response.StatusCode;
                using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
                {
                    strResponseValue = rdr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new HttpListenerException(e.GetHashCode(), e.Message);
            }

            return strResponseValue;
        }
    }
}
