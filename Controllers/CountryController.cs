using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budalapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Budalapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            var retval = await _countryService.ListAsync();
            return retval;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
