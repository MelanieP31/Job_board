using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Users{
    [Key]
    [Column("user_id")]
    public int UserId {get; set;}

    [Column("first_name")]
    public string? FirstName {get; set;}

    [Column("last_name")]
    public string? LastName {get; set;}

    [Column("email")]
    [Required]
    public string? Email {get; set;}

    [Column("phone")]
    public string? Phone {get; set;}

    [Column("description")]
    public string? Description {get; set;}

    [Column("password")]
    [Required]
    public string Password {get; set;}

    [Column("city")]
    public string? City {get; set;}

    [Column("user_type")]
    public string? UserType {get; set;}

    [Column("creation_date")]
    public DateTime? CreationDate {get; set;}

}