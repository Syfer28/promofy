using PROMHUB.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserSettings
{
    [Key]
    public int Id { get; set; }

    // Внешний ключ на таблицу пользователей
    [ForeignKey("User")]
    public int UserId { get; set; }


    [StringLength(50)]
    public string Email { get; set; }

    [StringLength(15)]
    public string Phone { get; set; }

    [StringLength(255)]
    public string PasswordHash { get; set; }

    public byte[] Photo { get; set; }

    [StringLength(20)]
    public string Language { get; set; }
    
    [StringLength(30)]
    public string Country { get; set; }

    [StringLength(30)]
    public string City { get; set; }

}
