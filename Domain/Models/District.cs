
using System.ComponentModel.DataAnnotations;

namespace Budalapi.Domain.Models
{
    public class District
    {
        public int Id { get; set; }
        public int CityId {get;set;}
        
        [MaxLength(30)]
        public string Name { get; set; }
    }
}