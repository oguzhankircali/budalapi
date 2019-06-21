using Budalapi.Domain.Models;

namespace Budalapi.Services.Communication
{
    public class SaveCityResponse : BaseResponse
    {
        public City City { get; private set; }

        private SaveCityResponse(bool success, string message, City country) : base(success, message)
        {
            City = country;
        }

        public SaveCityResponse(City City) : this(true, string.Empty, City)
        {

        }

        public SaveCityResponse(string message) : this(false, message, null)
        {

        }
    }
}