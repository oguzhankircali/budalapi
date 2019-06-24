
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budalapi.Domain.Models
{
    public class City
    {
        public int Id { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }
        public ICollection<District> Districts { get; set; }
    }
}