namespace HotelListing.API.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}
