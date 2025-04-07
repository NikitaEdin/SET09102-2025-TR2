

namespace REA.Models
{
    public class Sites
    {
        public int siteID { get; set; }
        public string siteName { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public int evelvation { get; set; }
        public string timezone { get; set; }
        public int utcOffset { get; set; }
        public string type { get; set; }
        public string zone { get; set; }
        public string agglomeration { get; set; }
        public string localAuthority { get; set; }

    }
}
