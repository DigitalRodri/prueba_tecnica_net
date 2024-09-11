namespace Domain.DTOs
{
    public class RetailerDto
    {
        public int ReId { get; set; }
        public string ReName { get; set; }
        public string Country { get; set; }
        public string CodingScheme { get; set; }
        public string ReCode { get; set; }

        public RetailerDto()
        {
        }

        public RetailerDto(int reId, string reName, string country, string codingScheme, string reCode)
        {
            this.ReId = reId;
            this.ReName = reName;
            this.Country = country;
            this.CodingScheme = codingScheme;
            this.ReCode = reCode;
        }
    }
}
