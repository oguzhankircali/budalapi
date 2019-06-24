
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budalapi.Domain.Models
{
    public class District
    {
        public int Id { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }
        
        [MaxLength(30)]
        public string Name { get; set; }
    }
}