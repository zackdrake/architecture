using System;

namespace API_Archi
{
    public class Flight
    {
        public int id { get; set; }

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

        public Flight(int id, string airport_start, string airport_arrival, Flight Next, int price, int nb_max_places, Type type, Source source)
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
            string text = string.Empty;
            if (Next != null) { text = Next.ToString(); }
            else { text = price + " €"; }
            if (type == Type.Train)
            {
                return airport_start + " - " + airport_arrival + " (TRAIN) : " + text;
            }
            return airport_start + " - " + airport_arrival + " : " + text;
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
    }
}
