using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [StringLength(25)]
        public required string Name { get; set; }

        [StringLength(25)]
        public required string LastName { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [Length(6,25)]
        public required string Password { get; set; }

        [Length(6, 25)]
        public required string ConfirmPassword { get; set; }

        public ICollection<Review>? Reviews { get; set; }
    }
}