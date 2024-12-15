using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class UserExperiences
{
    [Column("user_id")]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public Users? User { get; set; }

    [Column("experience_id")]
    public int ExperienceId { get; set; }

    [ForeignKey("ExperienceId")]
    public Experiences? Experience { get; set; }
}
