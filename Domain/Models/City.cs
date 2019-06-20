
using System.ComponentModel.DataAnnotations;

namespace Budalapi.Domain.Models
{
    public class City
    {
        public int Id { get; set; }
        public int CountryId {get;set;}
        
        [MaxLength(30)]
        public string Name { get; set; }
    }
}