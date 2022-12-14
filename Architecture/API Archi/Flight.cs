using System;
using System.Collections.Generic;

namespace API_Archi
{
    public class Flight
    {
        public string id { get; set; }

        public string airport_start { get; set; }

        public string airport_arrival { get; set; }

        public Flight Next { get; set; }

        public int price { get; set; }

        public int nb_max_places { get; set; }

        public Type type { get; set; }

        public Source source { get; set; }

        public enum Type
        {
            Train,
            Flight
        }

        public enum Source
        {
            intern,
            groupSeven,
            external,
            broker
        }

        public Flight(string id, string airport_start, string airport_arrival, Flight Next, int price, int nb_max_places, Type type, Source source)
        {
            this.id = id;
            this.airport_start = airport_start;
            this.airport_arrival = airport_arrival;
            this.Next = Next;
            this.price = price;
            this.nb_max_places = nb_max_places;
            this.type = type;
            this.source = source;
        }

        public override string ToString()
        {
            string text;
            if (Next != null) { text = Next.ToString(); }
            else { text = price + " EUR"; }
            if (type == Type.Train)
            {
                return source + " > " + airport_start + " - " + airport_arrival + " (TRAIN) : " + text;
            }
            return source + " > " + airport_start + " - " + airport_arrival + " : " + text;
        }

        public bool IsThereATrain()
        {
            if (type == Type.Train)
            {
                return true;
            }
            else
            {
                if (Next != null)
                {
                    return Next.IsThereATrain();
                }
                else
                {
                    return false;
                }
            }
        }
        public List<string> StopAirPorts()
        {
            List<string> StopsTab = StopAirPortsCicle();

            StopsTab.Remove(StopsTab[0]);
            StopsTab.Remove(StopsTab[StopsTab.Count - 1]);

            return StopsTab;
        }

        private List<string> StopAirPortsCicle()
        {
            List<string> StopsTab = new List<string>();

            StopsTab.Add(airport_start);

            if (Next != null)
            {
                List<string> StopsTabChild = Next.StopAirPortsCicle();

                foreach (string txt in StopsTabChild)
                {
                    StopsTab.Add(txt);
                }
            }
            else
            {
                StopsTab.Add(airport_arrival);
            }

            return StopsTab;
        }

        public List<BrokerAvailableOptions> GetFlightOptions()
        {
            List<BrokerAvailableOptions> flightOptions = new List<BrokerAvailableOptions>();

            flightOptions.Add(new BrokerAvailableOptions("luggage", "01", 10));
            flightOptions.Add(new BrokerAvailableOptions("childReduction", "02", 50));
            flightOptions.Add(new BrokerAvailableOptions("trainFirstClassOption", "03", 50));

            return flightOptions;
        }
    }
}
