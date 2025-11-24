using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models
{
    public class Country
    {
        public int Id { get; set; }

        [StringLength(50)]
        public required string Name { get; set; }

        [StringLength(4)]
        public required string ShortName { get; set; }
        public ICollection<Hotel>? Hotels { get; set; }
    }
}
