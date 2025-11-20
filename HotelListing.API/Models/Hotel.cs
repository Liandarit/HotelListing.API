namespace HotelListing.API.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rate { get; set; } = 0.0;
    }
}
