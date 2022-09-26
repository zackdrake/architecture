using System;

namespace API_Archi{

    public class BrokerPerson
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string birth_date { get; set; } //"23/09/2022"
        public BrokerPerson(string first_name, string last_name, string birth_date){
            this.first_name = first_name;
            this.last_name = last_name;
            this.birth_date = birth_date;
        }
    }
}

