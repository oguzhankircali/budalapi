using Budalapi.Domain.Models;

namespace Budalapi.Services.Communication
{
    public class SaveCountryResponse : BaseResponse
    {
        public Country Country { get; private set; }

        private SaveCountryResponse(bool success, string message, Country country) : base(success, message)
        {
            Country = country;
        }

        public SaveCountryResponse(Country Country) : this(true, string.Empty, Country)
        {

        }

        public SaveCountryResponse(string message) : this(false, message, null)
        {

        }
    }
}