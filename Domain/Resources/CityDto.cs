using System.ComponentModel.DataAnnotations.Schema;

namespace Budalapi.Domain.Resources
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}