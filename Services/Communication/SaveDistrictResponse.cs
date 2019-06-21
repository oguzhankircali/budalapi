using Budalapi.Domain.Models;

namespace Budalapi.Services.Communication
{
    public class SaveDistrictResponse : BaseResponse
    {
        public District District { get; private set; }

        private SaveDistrictResponse(bool success, string message, District country) : base(success, message)
        {
            District = country;
        }

        public SaveDistrictResponse(District District) : this(true, string.Empty, District)
        {

        }

        public SaveDistrictResponse(string message) : this(false, message, null)
        {

        }
    }
}