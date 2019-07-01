
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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CityService(ICityRepository cityRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<City> GetAsync(int countryId)
        {
            return await _cityRepository.FindByIdAsync(countryId);
        }
        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _cityRepository.ListAsync();
        }

        public async Task<IEnumerable<City>> ListByCountryIdAsync(int countryId)
        {
            return await _cityRepository.ListByCountryIdAsync(countryId);
        }

        public async Task<SaveCityResponse> SaveAsync(City category)
        {
            try
            {
                await _cityRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new SaveCityResponse(category);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveCityResponse("An error occurred when saving the category:" + ex.Message);
            }
        }

        public async Task<SaveCityResponse> UpdateAsync(int id, City category)
        {
            var existingCity = await _cityRepository.FindByIdAsync(id);
            if (existingCity == null)
            {
                return new SaveCityResponse("City not found");
            }

            existingCity.Name = category.Name;

            try
            {
                _cityRepository.Update(existingCity);
                await _unitOfWork.CompleteAsync();

                return new SaveCityResponse(existingCity);
            }
            catch (System.Exception ex)
            {
                return new SaveCityResponse("An error occurred when updating the category: " + ex.Message);
            }
        }

        public async Task<SaveCityResponse> DeleteAsync(int id)
        {
            await _cityRepository.Delete(id);
            return new SaveCityResponse($"The city with {id}, has been removed.");
        }
    }
}