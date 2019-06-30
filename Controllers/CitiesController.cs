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
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IDistrictService _districtService;
        private readonly IMapper _mapper;

        public CitiesController(ICityService cityService, IDistrictService districtService, IMapper mapper)
        {
            _cityService = cityService;
            _districtService = districtService;
            _mapper = mapper;
        }
        // GET api/cities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var retval = await _cityService.GetAsync(id);
            return Ok(_mapper.Map<City, CityDto>(retval));
        }

        // GET api/cities
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var retval = await _cityService.ListAsync();
            var resources = _mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(retval);
            return Ok(resources);
        }

        [Route("GetAllByCountryId/{countryId}")]
        public async Task<IActionResult> GetAllByCountryId(int countryId)
        {
            var data = await _cityService.ListByCountryIdAsync(countryId);
            return Ok(_mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(data));
        }


        // POST api/cities
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCityModel resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = _mapper.Map<SaveCityModel, City>(resource);
            var result = await _cityService.SaveAsync(category);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var itemResource = _mapper.Map<City, CityDto>(result.City);
            return Ok(itemResource);
        }

        // PUT api/cities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SaveCityModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var existData = await _cityService.GetAsync(id);
            if (existData != null)
            {
                existData.Name = model.Name;
            }

            var response = await _cityService.UpdateAsync(id, existData);
            return Ok(response);
        }

        // DELETE api/cities/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
