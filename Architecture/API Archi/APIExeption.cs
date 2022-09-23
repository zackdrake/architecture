using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Archi
{
    public class APIExeption : Exception
    {
        public ExeptionType exeptionType { get; }
        public override string Message { get; }

        public enum ExeptionType
        {
            FlightFull,
            IllegalPrice,
            ObjectNotFound
        }

        public APIExeption(ExeptionType exeptionType)
        {
            this.exeptionType = exeptionType;
            Message = MessageInit();
        }

        private string MessageInit()
        {
            switch (exeptionType)
            {
                case ExeptionType.FlightFull:

                    return "The flight selected is full.";

                case ExeptionType.IllegalPrice:

                    return "The price paid is null or negative.";

                case ExeptionType.ObjectNotFound:

                    return "The object searched isn't found.";

                default:

                    return "";
            }
        }
    }
}
