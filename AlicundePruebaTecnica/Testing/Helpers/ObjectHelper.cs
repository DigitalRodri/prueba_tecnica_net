using Domain.DTOs;
using Domain.Entities;

namespace Testing.Helpers
{
    public static class ObjectHelper
    {
        public const int ReId = 88;
        public const string ReName = "Altid Energi ApS";
        public const string Country = "DK";
        public const string CodingScheme = "GS1";
        public const string ReCode = "5790002777646";

        public static Retailer GetRetailer()
        {
            return new Retailer(ReId, ReName, Country, CodingScheme, ReCode, DateTime.Now, DateTime.Now.AddMinutes(20));
        }

        public static IEnumerable<Retailer> GetRetailerList()
        {
            return new List<Retailer>() { GetRetailer(), GetRetailer() };
        }

        public static RetailerDto GetRetailerDto()
        {
            return new RetailerDto(ReId, ReName, Country, CodingScheme, ReCode);
        }

        public static IEnumerable<RetailerDto> GetRetailerDtoList()
        {
            return new List<RetailerDto>() { GetRetailerDto(), GetRetailerDto() };
        }
    }
}
