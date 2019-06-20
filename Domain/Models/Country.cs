
using System.ComponentModel.DataAnnotations;

namespace Budalapi.Domain.Models
{
    public class Country
    {
        public int Id { get; set; }

        [MaxLength(3)]
        public string ISO1366_Alpha2 { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; }
        public int PhoneCode {get;set;}
    }
}