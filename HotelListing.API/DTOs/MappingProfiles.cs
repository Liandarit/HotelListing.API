using AutoMapper;
using HotelListing.API.DTOs.CountryDTOs;
using HotelListing.API.DTOs.HotelsDTOs;
using HotelListing.API.DTOs.ReviewDTOs;
using HotelListing.API.Models;

namespace HotelListing.API.DTOs
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles() 
        {
            // Review Mappings
            CreateMap<CreateReviewDto, Review>();
            CreateMap<Review, GetReviewsDto>().ReverseMap();
            CreateMap<UpdateReviewDto, Review>().ReverseMap();

            // Hotel Mappings
            CreateMap<Hotel, GetHotelDto>().ReverseMap();
            CreateMap<CreateHotelDto, Hotel>();
            CreateMap<UpdateHotelDto,Hotel>().ReverseMap();

            //Country Mappings
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<CreateCountryDto, Country>().ReverseMap();
            CreateMap<UpdateCountryDto, Country>().ReverseMap();
        }

    }
}
