using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Budalapi.Domain.Models;
using Budalapi.Domain.Resources;
using Budalapi.Services;
using Microsoft.AspNetCore.Mvc;
using Budalapi.Extensions;

namespace Budalapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountriesController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }
        // GET api/countries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _countryService.GetAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            var retval = _mapper.Map<Country, CountryDto>(data);
            return Ok(retval);
        }

        // GET api/countries
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _countryService.ListAsync();
            var retval = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(data);
            return Ok(retval);
        }


        // POST api/countries
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCountryModel resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var data = _mapper.Map<SaveCountryModel, Country>(resource);
            var result = await _countryService.SaveAsync(data);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var itemResource = _mapper.Map<Country, CountryDto>(result.Country);
            return Ok(itemResource);
        }

        // PUT api/countries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SaveCountryModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existData = await _countryService.GetAsync(id);
                if (existData != null)
                {
                    existData.Name = model.Name;
                }

                await _countryService.UpdateAsync(id, existData);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // DELETE api/countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Country country = await _countryService.GetAsync(id);
                if (country == null)
                {
                    return NotFound("Country is not found!");
                }

                await _countryService.DeleteAsync(country.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
