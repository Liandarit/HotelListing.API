using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int HotelId { get; set; }
        public int UserId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public Hotel? Hotel { get; set; }
        public User? User { get; set; }

    }
}
