using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PROMHUB.Data.Models
{
    public class ProductList
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        public int UserId { get; set; }

        [JsonIgnore] // Исключает свойство из сериализации в JSON
        public User User { get; set; }
        public int ProductId { get; set; }

        [JsonIgnore] // Исключает свойство из сериализации в JSON
        public Product Product { get; set; }


    }
}
