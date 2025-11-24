using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.DTOs.ReviewDTOs
{
    public class UpdateReviewDto : CreateReviewDto
    {
        [Required]
        public int Id { get; set; }
    }
}
