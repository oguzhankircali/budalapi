using System.ComponentModel.DataAnnotations;

namespace Budalapi.Domain.Resources
{
    public class SaveCityModel
    {
        public int CountryId { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; }
    }
}