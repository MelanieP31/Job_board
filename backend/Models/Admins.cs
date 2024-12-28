using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Admins
{
    [Key]
    [Column("admin_id")]
    public int AdminId { get; set; }

    [Column("email")]
    [Required]
    public required string Email { get; set; }

    [Column("password")]
    [Required]
    public required string Password { get; set; }
}
