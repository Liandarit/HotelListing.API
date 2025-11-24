using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.DTOs.CountryDTOs
{
    public class CreateCountryDto
    {
        [StringLength(50)]
        public required string Name { get; set; }

        [StringLength(4)]
        public required string ShortName { get; set; }
    }
}
