
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Budalapi.Domain.Models;
using Budalapi.Domain.Resources;
using Budalapi.Repositories;
using Budalapi.Services.Communication;

namespace Budalapi.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DistrictService(IDistrictRepository countryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _districtRepository = countryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<District> GetAsync(int countryId)
        {
            return await _districtRepository.FindByIdAsync(countryId);
        }
        public async Task<IEnumerable<District>> ListAsync()
        {
            return await _districtRepository.ListAsync();
        }

        public async Task<IEnumerable<District>> ListByCityIdAsync(int cityId)
        {
            return await _districtRepository.ListByCityIdAsync(cityId);
        }

        public async Task<SaveDistrictResponse> SaveAsync(District category)
        {
            try
            {
                await _districtRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new SaveDistrictResponse(category);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveDistrictResponse("An error occurred when saving the category:" + ex.Message);
            }
        }

        public async Task<SaveDistrictResponse> UpdateAsync(int id, District category)
        {
            var existingDistrict = await _districtRepository.FindByIdAsync(id);
            if (existingDistrict == null)
            {
                return new SaveDistrictResponse("District not found");
            }

            existingDistrict.Name = category.Name;

            try
            {
                _districtRepository.Update(existingDistrict);
                await _unitOfWork.CompleteAsync();

                return new SaveDistrictResponse(existingDistrict);
            }
            catch (System.Exception ex)
            {
                return new SaveDistrictResponse("An error occurred when updating the category: " + ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _districtRepository.Delete(id);
        }
    }
}