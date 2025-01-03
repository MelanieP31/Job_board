namespace backend.DTO
{
    public class CompaniesDTO{
        public int CompanyId {get; set;}
        public required string Name {get; set;}
        public required string Email {get; set;}
        public string? Description {get; set;}
        public string? Location {get; set;}
    }

}