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
    public class DistrictController : Controller
    {
        private readonly IDistrictService _districtService;
        private readonly IMapper _mapper;

        public DistrictController(IDistrictService districtService, IMapper mapper)
        {
            _districtService = districtService;
            _mapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<DistrictDto>> GetAllAsync()
        {
            var retval = await _districtService.ListAsync();
            var resources = _mapper.Map<IEnumerable<District>, IEnumerable<DistrictDto>>(retval);
            return resources;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var retval = await _districtService.GetAsync(id);
            return Ok(retval);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDistrictDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var data = _mapper.Map<SaveDistrictDto, District>(resource);
            var result = await _districtService.SaveAsync(data);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var itemResource = _mapper.Map<District, DistrictDto>(result.District);
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
