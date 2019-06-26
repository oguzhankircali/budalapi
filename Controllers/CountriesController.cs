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
        public async Task<IActionResult> PostAsync([FromBody] SaveCountryDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var data = _mapper.Map<SaveCountryDto, Country>(resource);
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
        public async Task<IActionResult> Put(int id, [FromBody] SaveCountryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var existData = await _countryService.GetAsync(id);
            if (existData != null)
            {
                existData.Name = dto.Name;
            }

            var response = await _countryService.UpdateAsync(id, existData);
            return Ok(response);
        }

        // DELETE api/countries/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _countryService.DeleteAsync(id);
        }
    }
}
