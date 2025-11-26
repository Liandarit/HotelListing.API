namespace HotelListing.API.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

        //Tüm entityler için sabit olacak þekilde tasarlandý.
        //Ýleride bir class için ayrý bir þey gerekirse o class'a özel ayrý repo classlar oluþtulur.

    }
}
