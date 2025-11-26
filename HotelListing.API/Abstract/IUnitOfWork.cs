using HotelListing.API.Repositories;

namespace HotelListing.API.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        IHotelsRepository Hotels { get; }
        ICountryRepository Countries { get; }
        IReviewRepository Reviews { get; }
        IUserRepository Users { get; }
        Task<int> SaveAsync();
    }
}
