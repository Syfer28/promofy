using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PROMHUB.Data.Models
{

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Photo { get; set; }

        [Required]
        public double Price { get; set; }

        public int Discount { get; set; }

        public ProductList ProductList { get; set; }

        public ICollection<ProductShop> ProductShops { get; set; }
        public ICollection<CompanyProduct> CompanyProducts { get; set; }

    }
}
