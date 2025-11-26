using HotelListing.API.Abstract;
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(HotelListingDb context)
        {
            this.context = context;
            Hotels= new HotelsRepository(context);
            Countries= new CountryRepository(context);
            Reviews= new ReviewRepository(context);
            Users = new UserRepository(context);
        }

        private readonly HotelListingDb context;
        public IHotelsRepository Hotels { get; private set; }
        public ICountryRepository Countries { get; private set; }
        public IReviewRepository Reviews { get; private set; }
        public IUserRepository Users { get; private set; }
        public async Task<int> SaveAsync() {return await context.SaveChangesAsync(); }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
