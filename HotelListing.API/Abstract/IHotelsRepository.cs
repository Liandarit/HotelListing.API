using HotelListing.API.Models;
using HotelListing.API.Repository;

namespace HotelListing.API.Abstract
{
    public interface IHotelsRepository:IBaseRepository<Hotel>
    {
        Task<IEnumerable<Hotel>> GetTopRatedHotels(int rate);
        Task<IEnumerable<Hotel>> GetHotelsByCity(int  countryId);
        Task<IEnumerable<Hotel>> GetHotelsWithReviewsCountry();
    }
}
