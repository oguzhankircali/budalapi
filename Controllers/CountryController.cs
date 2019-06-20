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
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<CountryResource>> GetAllAsync()
        {
            var retval = await _countryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(retval);
            return resources;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCountryResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = _mapper.Map<SaveCountryResource, Country>(resource);
            var result = await _countryService.SaveAsync(category);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var itemResource = _mapper.Map<Country, CountryResource>(result.Country);
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
    }
}
