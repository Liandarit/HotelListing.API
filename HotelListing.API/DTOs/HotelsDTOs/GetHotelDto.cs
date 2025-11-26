using HotelListing.API.DTOs.ReviewDTOs;
using HotelListing.API.Models;

namespace HotelListing.API.DTOs.HotelsDTOs
{
    public class GetHotelDto
    {
      
        public required string Name { get; set; }
        public required string Address { get; set; }
        public double Rate { get; set; }
        public required int CountryId { get; set; }
        public ICollection<GetReviewsDto>? Reviews { get; set; }
    }
}
