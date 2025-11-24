using HotelListing.API.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace HotelListing.API.DTOs.ReviewDTOs
{
    public class CreateReviewDto
    {
        [Range(1, 5)]
        public required int Rating { get; set; }

        [Required]
        [StringLength(250)]
        public required string Comment { get; set; }
        public required int HotelId { get; set; }
        public required int UserId { get; set; }
    }
}
