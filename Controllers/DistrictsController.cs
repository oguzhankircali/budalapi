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
using Budalapi.Services.Communication;
using Microsoft.AspNetCore.Http;

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
            if (data == null)
            {
                return NotFound();
            }

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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDistrictModel resource)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
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
            catch (System.Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SaveDistrictModel model)
        {
            try
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

                await _districtService.UpdateAsync(id, existData);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                District district = await _districtService.GetAsync(id);
                if (district == null)
                {
                    return NotFound("District is not found!");
                }

                await _districtService.DeleteAsync(district.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
