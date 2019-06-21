using System.ComponentModel.DataAnnotations;

namespace Budalapi.Domain.Resources
{
    public class SaveCityDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}