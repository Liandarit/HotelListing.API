namespace HotelListing.API.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rate { get; set; } = 0.0;
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
