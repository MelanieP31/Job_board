using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Applications{
    [Key]
    [Column("app_id")]
    public int AppId {get; set;}

    [Column("app_date")]
    [Required]
    public DateTime? AppDate {get; set;} = DateTime.Now;

    [Column("message")]
    public string? Message {get; set;}

    [Column("status")]
    [Required]
    public string Status {get; set;} = "in progress";

    //FK
    [Column("job_id")]
    public int JobId {get; set; }

    [ForeignKey("JobId")]
    public Joboffer? JobOffer; 

    [Column("user_id")]
    public int UserId{get; set; }

    [ForeignKey("UserId")]
    public Users? User; 

}