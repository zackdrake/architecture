using System;

namespace API_Archi{
    public enum OptionType{
        BonusLuggage,
        FirstClass,
        ChampagneOnBoard,
        LoungeAccess,
    }
    public class ExternalFlightOptions
    {
        public OptionType OptionType { get; set; }
        public int price { get; set; }
        public ExternalFlightOptions(OptionType OptionType, int price){
            this.OptionType = OptionType;
            this.price = price;
        }
    }
}

