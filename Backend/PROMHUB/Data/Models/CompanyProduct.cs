using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROMHUB.Data.Models
{
    public class CompanyProduct
    {
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}
