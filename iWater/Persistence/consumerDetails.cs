using System;
namespace iWater.Persistence
{
    public class consumerDetails
    {
        public string wmrid { get; set; }
        public string wmwcid { get; set; }
        public string ownername { get; set; }
        public double prevreadingvalue { get; set; }
        public string serialno { get; set; }

        public DateTime readingdate { get; set; }
        public double readingvalue { get; set; }
    }
}
