using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class UserFormations
{
    [Column("user_id")]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public Users? User { get; set; }

    [Column("formation_id")]
    public int FormationId { get; set; }

    [ForeignKey("FormationId")]
    public Formations? Formation { get; set; }
}
