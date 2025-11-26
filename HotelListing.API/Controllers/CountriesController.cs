using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.DTOs.CountryDTOs;
using HotelListing.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController(HotelListingDb context, IMapper mapper) : ControllerBase
    {
        private readonly HotelListingDb context = context;
        private IMapper mapper = mapper;

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountriesDto>>> GetCountries()
        {

            var data= await context.Countries
                .AsNoTracking()
                .Include(c=>c.Hotels)
                .ToListAsync();
            var countriesDto= mapper.Map<GetCountriesDto>(data);
            return Ok(countriesDto);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountryDto>> GetCountry(int id)
        {
            var country = await context.Countries
                .AsNoTracking()
                .Include(c=>c.Hotels)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (country == null)
            {
                return NotFound();
            }
            var CountryDto=mapper.Map<GetCountryDto>(country);
            return CountryDto;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var country = await context.Countries.FindAsync(id);

            if (country == null) { return NotFound(); }
            mapper.Map(dto, country);

            await context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto dto)
        {
            if (dto == null) { return BadRequest(); }
            var country= mapper.Map<Country>(dto);
            context.Countries.Add(country);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            context.Countries.Remove(country);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return context.Countries.Any(e => e.Id == id);
        }
    }
}
