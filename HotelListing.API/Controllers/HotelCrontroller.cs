using HotelListing.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelCrontroller : ControllerBase
    {

        private static List<Hotel> HotelList = new List<Hotel>
        {
            new Hotel{Id=1, Address="Gaziantep", Name="Grand Turkish", Rate=4.5},
            new Hotel{Id=2, Address="Ankara", Name="Grand Ankara", Rate=4.0}
        };
        
        // GET: api/<HotelCrontroller>
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            return Ok(HotelList);
        }

        // GET api/<HotelCrontroller>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Hotel>> Get(int id)
        {
            var hotel = HotelList.FirstOrDefault(h=> h.Id==id);
            if (hotel == null) { return NotFound(); }
            return Ok(hotel);
        }

        // POST api/<HotelCrontroller>
        [HttpPost]
        public ActionResult Post([FromBody] Hotel hotel)
        {
            if (HotelList.Any(h => h.Id == hotel.Id) == true)
            {
                return BadRequest("Hotel with this Id already exist.");
            }

            HotelList.Add(hotel);
            return CreatedAtAction(nameof(Get), new { id=hotel.Id },hotel);
        }

        // PUT api/<HotelCrontroller>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Hotel UpdatedHotel)
        {
            var existingHotel = HotelList.FirstOrDefault(h => h.Id == UpdatedHotel.Id);
            if (existingHotel==null) { return BadRequest(); }
            HotelList.Remove(existingHotel);
            HotelList.Add(UpdatedHotel);

            return Ok();
            

        }

        // DELETE api/<HotelCrontroller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var hotel = HotelList.FirstOrDefault(hotel=>hotel.Id==id);
            if (hotel == null) { return  BadRequest(); }
            HotelList.Remove(hotel);
            return Ok();
        }
    }
}
