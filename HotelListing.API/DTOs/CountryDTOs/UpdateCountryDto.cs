using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.DTOs.CountryDTOs
{
    public class UpdateCountryDto:CreateCountryDto
    {
        [Required]
        public int Id { get; set; }
    }
}
