using HotelListing.API.Abstract;
using HotelListing.API.Data;
using HotelListing.API.Models;
using HotelListing.API.Repository;

namespace HotelListing.API.Repositories
{
    public class UserRepository(HotelListingDb context) : BaseRepository<User>(context), IUserRepository
    {

    }
}
