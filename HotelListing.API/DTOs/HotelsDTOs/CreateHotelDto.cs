using HotelListing.API.Models;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.DTOs.HotelsDTOs;

public class CreateHotelDto
{
    public required string Name { get; set; }
    [StringLength(150)]
    public required string Address { get; set; }

    [Range(0, 5)]
    public double Rate { get; set; } = 0.0;
    public required int CountryId { get; set; } 

}
