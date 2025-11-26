using HotelListing.API.Abstract;
using HotelListing.API.Data;
using HotelListing.API.Models;
using HotelListing.API.Repository;

namespace HotelListing.API.Repositories
{
    public class ReviewRepository(HotelListingDb context) : BaseRepository<Review>(context), IReviewRepository
    {
    }
}
