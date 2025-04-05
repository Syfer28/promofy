using System.ComponentModel.DataAnnotations;

namespace PROMHUB.Data.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public string Photo { get; set; }

        public CompanyInfo CompanyInfo { get; set; }

        public ICollection<CompanyProduct> CompanyProduct { get; set; }

    }
}