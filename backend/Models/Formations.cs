

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Formations{
    [Key]
    [Column("formation_id")]
    public int FormationId {get; set; }

    [Column("institution")]
    public string? Institution {get; set; }

    [Column("name")]
    public string? Name {get; set; }

    [Column("start_date")]
    public DateTime? StartDate {get; set; }

    [Column("end_date")]
    public DateTime? EndDate {get; set; }

    [Column("description")]
    public string? Description {get; set; }

    [Column("user_id")]
    public int UserId {get; set; }

    [ForeignKey("UserId")]
    public Users? User {get; set;}


}