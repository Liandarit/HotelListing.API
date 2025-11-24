using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models;

public class Hotel
{
    public int Id { get; set; }

    public required string Name { get; set; }

    [StringLength(150)]
    public required string Address { get; set; }
    [Range(0, 5)]
    public double Rate { get; set; } = 0.0;
    public required int CountryId { get; set; }
    public Country? Country { get; set; }
    public ICollection<Review>? Reviews { get; set; }

}
