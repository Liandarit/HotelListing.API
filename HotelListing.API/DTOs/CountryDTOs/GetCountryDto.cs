using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.DTOs.CountryDTOs
{
    public class GetCountryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ShortName { get; set; }
    }
}
