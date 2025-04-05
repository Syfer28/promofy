using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PROMHUB.Data.Models
{
    public class CompanyInfo
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(400)]
        public string Description { get; set; }

        [StringLength(15)]
        public string ContactPhone { get; set; }

        [StringLength(40)]
        public string ContactEmail { get; set; }

        // Навигационное свойство к таблице Company
        public Company Company { get; set; }
    }
}
