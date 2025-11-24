using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Models;
using AutoMapper;
using HotelListing.API.DTOs.HotelsDTOs;

namespace HotelListing.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController(HotelListingDb context, IMapper mapper) : ControllerBase
{
    public readonly IMapper mapper = mapper;

    // GET: api/Hotels
    [HttpGet]
    public async Task<ActionResult<GetHotelsDto>> GetHotels()
    {
        var hotels = await context.Hotels
            .Include(h=>h.Country)
            .Include(h=>h.Reviews)
            .ToListAsync();
        var HotelsDto = mapper.Map<GetHotelsDto>(hotels);
        return Ok(HotelsDto);
    }

    // GET: api/Hotels/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GetHotelDto>> GetHotel(int id)
    {
        var hotel = await context.Hotels
            .Include(h=>h.Country)
            .Include (h=>h.Reviews)
            .FirstOrDefaultAsync(h=>h.Id==id);

        if (hotel == null)
        {
            return NotFound();
        }
        var HotelDto= mapper.Map<GetHotelDto>(hotel);
        return HotelDto;
    }

    // PUT: api/Hotels/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHotel(int id, UpdateHotelDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest();
        }
        var hotel = await context.Hotels.FindAsync(id);

        if (hotel == null) { return NotFound(); }
        mapper.Map(dto,hotel);

        await context.SaveChangesAsync();

        return NoContent();
    }

    // POST: api/Hotels
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDto dto)
    {
        var hotel = mapper.Map<Hotel>(dto);
        context.Hotels.Add(hotel);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
    }

    // DELETE: api/Hotels/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        var hotel = await context.Hotels.FindAsync(id);
        if (hotel == null)
        {
            return NotFound();
        }

        context.Hotels.Remove(hotel);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool HotelExists(int id)
    {
        return context.Hotels.Any(e => e.Id == id);
    }
}
