using HotelListing.API.Abstract;
using HotelListing.API.Data;
using HotelListing.API.Models;
using HotelListing.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repositories
{
    public class HotelsRepository(HotelListingDb context) : BaseRepository<Hotel>(context), IHotelsRepository
    {
        public async Task<IEnumerable<Hotel>> GetHotelsByCity(int CountryId)
        {
            var hotels = await dbSet.OrderByDescending(h=>h.Name)
                .Where(h=>h.CountryId == CountryId).ToListAsync();
            return hotels;
        }

        public async Task<IEnumerable<Hotel>> GetTopRatedHotels(int Rate)
        {
            var hotels = await dbSet.OrderByDescending (h=>h.Rate)
                .Where(h=>h.Rate>= Rate).ToListAsync();
            return hotels;
        }
        public async Task<IEnumerable<Hotel>> GetHotelsWithReviewsCountry()
        {
            var hotels = await dbSet
                .Include(h => h.Reviews).ThenInclude(r=>r.User)
                .Include(h=>h.Country)
                .ToListAsync();
            return hotels;
        }
    }
}
