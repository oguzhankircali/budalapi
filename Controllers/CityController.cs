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
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IDistrictService _districtService;
        private readonly IMapper _mapper;

        public CityController(ICityService cityService, IDistrictService districtService, IMapper mapper)
        {
            _cityService = cityService;
            _districtService = districtService;
            _mapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {
            var retval = await _cityService.ListAsync();
            var resources = _mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(retval);
            return resources;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var retval = await _cityService.GetAsync(id);
            return Ok(retval);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCityDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = _mapper.Map<SaveCityDto, City>(resource);
            var result = await _cityService.SaveAsync(category);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var itemResource = _mapper.Map<City, CityDto>(result.City);
            return Ok(itemResource);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("{id}/Districts")]
        public async Task<IActionResult> Districts(int id)
        {
            var data = await _districtService.ListByCityIdAsync(id);
            var retval = _mapper.Map<IEnumerable<District>, IEnumerable<DistrictDto>>(data);
            return Ok(retval);

        }
    }
}
