using System.ComponentModel.DataAnnotations;

namespace Budalapi.Domain.Resources
{
    public class SaveDistrictResource
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}