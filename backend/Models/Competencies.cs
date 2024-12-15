using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Competencies{
    [Key]
    [Column("competency_id")]
    public int CompetencyId {get; set; }

    [Column("name")]
    public string? Name {get; set; }

    public ICollection<UserCompetencies>? UserCompetencies {get; set; }
}