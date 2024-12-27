using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Joboffer{
    [Key]
    [Column("job_id")]
    public int JobId {get; set;}

    [Column("title")]
    public string? Title {get; set;}

    [Column("short_description")]
    public string? ShortDescription {get; set;}

    [Column("long_description")]
    public string? LongDescription {get; set;}

    [Column("contract_type")]
    public string? ContractType {get; set;}

    [Column("creation_date")]
    public DateTime CreationDate {get; set;}

    [Column("location")]
    public string? Location {get; set;}

    //Relations
    [Column("company_id")]
    public int CompanyId {get; set;}   
    [ForeignKey("CompanyId")]
    public Companies? Company {get; set;}

    public ICollection<Applications>? Applications { get; set; }
}