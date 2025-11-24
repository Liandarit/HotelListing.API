using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.DTOs.ReviewDTOs
{
    public class GetReviewsDto
    {
        public int Id { get; set; }
        public required int Rating { get; set; }
        public required string Comment { get; set; }
        public required int HotelId { get; set; }
        public required int UserId { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }


    }
}