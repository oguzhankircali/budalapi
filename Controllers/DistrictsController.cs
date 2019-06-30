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
    public class DistrictsController : Controller
    {
        private readonly IDistrictService _districtService;
        private readonly IMapper _mapper;

        public DistrictsController(IDistrictService districtService, IMapper mapper)
        {
            _districtService = districtService;
            _mapper = mapper;
        }
        // GET api/districts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _districtService.GetAsync(id);
            return Ok(_mapper.Map<District, DistrictDto>(data));
        }

        // GET api/districts
        [HttpGet]
        public async Task<IEnumerable<DistrictDto>> Get()
        {
            var retval = await _districtService.ListAsync();
            var resources = _mapper.Map<IEnumerable<District>, IEnumerable<DistrictDto>>(retval);
            return resources;
        }

        [HttpGet("GetAllByCityId/{cityId}")]
        public async Task<IActionResult> GetAllByCityId(int cityId)
        {
            var retval = await _districtService.ListByCityIdAsync(cityId);
            var resources = _mapper.Map<IEnumerable<District>, IEnumerable<DistrictDto>>(retval);
            return Ok(resources);
        }


        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDistrictModel resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var data = _mapper.Map<SaveDistrictModel, District>(resource);
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
        public async Task<IActionResult> Put(int id, [FromBody] SaveDistrictModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var existData = await _districtService.GetAsync(id);
            if (existData != null)
            {
                existData.Name = model.Name;
            }

            var response = await _districtService.UpdateAsync(id, existData);
            return Ok(response);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _districtService.DeleteAsync(id);
            return Ok("Deleted.");
        }
    }
}
