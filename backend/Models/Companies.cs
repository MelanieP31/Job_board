using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Companies{
    [Key]
    [Column("company_id")]
    public int CompanyId {get; set;}

    [Column("name")]
    [Required]
    public required string Name {get; set;}

    [Column("email")]
    [Required]
    public required string Email {get; set;}

    [Column("description")]
    public string? Description {get; set;}

    [Column("password")]
    [Required]
    public required string Password {get; set;}

    [Column("location")]
    public string? Location {get; set;}

    [Column("validated")]
    public bool Validated {get; set;}

    //Relation One-To-Many 
    public ICollection<Joboffer>? JobOffers {get; set; }

}