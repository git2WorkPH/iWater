using SQLite;

namespace iWater.Persistence
{
    public class WMSYNC
    {
        [PrimaryKey]
        public string wmr_id { get; set; }

        [MaxLength(255)]
        public string ownername { get; set; }


        public string readingdate { get; set; }
        public double readingvalue { get; set; }
        public double prevreadingvalue { get; set; }
        public string serialno { get; set; }

    }
}
