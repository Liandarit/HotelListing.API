using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; }

        [Required]
        [StringLength(250)]
        public required string Comment { get; set; }
        public required int HotelId { get; set; }
        public required int UserId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public bool IsDeleted { get; set; }= false;

        public Hotel? Hotel { get; set; }
        public User? User { get; set; }

    }
}
