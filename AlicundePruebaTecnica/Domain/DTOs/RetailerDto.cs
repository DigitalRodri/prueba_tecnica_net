namespace Domain.DTOs
{
    public class RetailerDto
    {
        public int reId { get; set; }
        public string reName { get; set; }
        public string country { get; set; }
        public string codingScheme { get; set; }
        public string reCode { get; set; }

        public RetailerDto()
        {
        }

        public RetailerDto(int reId, string reName, string country, string codingScheme, string reCode)
        {
            this.reId = reId;
            this.reName = reName;
            this.country = country;
            this.codingScheme = codingScheme;
            this.reCode = reCode;
        }
    }
}
