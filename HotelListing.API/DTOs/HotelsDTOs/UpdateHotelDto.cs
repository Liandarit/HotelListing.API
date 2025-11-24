using HotelListing.API.Models;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.DTOs.HotelsDTOs
{
    public class UpdateHotelDto: CreateHotelDto
    {
        [Required]
        public required int Id { get; set; }
    }
}
