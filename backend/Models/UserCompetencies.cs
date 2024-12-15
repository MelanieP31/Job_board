using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class UserCompetencies{

    [Column("user_id")]
    public int UserId {get; set; }

    [ForeignKey("UserId")]
    public Users? User {get; set; }

    [Column("competency_id")]
    public int CompetencyId {get; set; }

    [ForeignKey("CompetencyId")]
    public Competencies? Competency {get; set; }
}