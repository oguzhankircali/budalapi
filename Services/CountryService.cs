
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Budalapi.Domain.Models;
using Budalapi.Repositories;
using Budalapi.Services.Communication;

namespace Budalapi.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CountryService(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Country>> ListAsync()
        {
            return await _countryRepository.ListAsync();
        }

        public async Task<SaveCountryResponse> SaveAsync(Country category)
        {
            try
            {
                await _countryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new SaveCountryResponse(category);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveCountryResponse("An error occurred when saving the category:" + ex.Message);
            }
        }

        public async Task<SaveCountryResponse> UpdateAsync(int id, Country category)
        {
            var existingCountry = await _countryRepository.FindByIdAsync(id);
            if (existingCountry == null)
            {
                return new SaveCountryResponse("Country not found");
            }

            existingCountry.Name = category.Name;

            try
            {
                _countryRepository.Update(existingCountry);
                await _unitOfWork.CompleteAsync();

                return new SaveCountryResponse(existingCountry);
            }
            catch (System.Exception ex)
            {
                return new SaveCountryResponse("An error occurred when updating the category: " + ex.Message);
            }
        }
    }
}