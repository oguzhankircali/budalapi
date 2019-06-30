using System.ComponentModel.DataAnnotations;

namespace Budalapi.Domain.Resources
{
    public class SaveDistrictModel
    {
        public int CityId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
    }
}