using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Experiences{
    [Key]
    [Column("experience_id")]
    public int ExperienceId {get; set; }

    [Column("company")]
    public string? CompanyName {get; set; }

    [Column("title")]
    public string? Title {get; set; }

    [Column("start_date")]
    public DateTime? StartDate {get; set;}

    [Column("end_date")]
    public DateTime? EndDate {get; set; }

    [Column("description")]
    public string? Description {get; set; }

    //FK
    public ICollection<UserExperiences>? UserExperiences { get; set; }

}