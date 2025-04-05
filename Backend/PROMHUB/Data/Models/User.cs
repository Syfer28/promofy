using System.ComponentModel.DataAnnotations;

namespace PROMHUB.Data.Models
{
    public class User
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public UserSettings UserSettings { get; set; }

        public ProductList ProductList { get; set; }

    }
}
