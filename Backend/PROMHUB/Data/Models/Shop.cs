using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROMHUB.Data.Models
{
    public class Shop
    {
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressString { get; set; }

        [StringLength(200)]
        public string Longitude { get; set; }

        [StringLength(200)]
        public string Latitude { get; set; }

        public int Rating { get; set; }

        // Навигационное свойство к компании
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public ICollection<ProductShop> ProductShops { get; set; }

    }
}
