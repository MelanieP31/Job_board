namespace backend.DTO 
{
    public class JobofferDTO {
        public int JobId {get; set;}
        public string? Title {get; set;}
        public string? ShortDescription {get; set;}
        public string? LongDescription {get; set;}
        public string? ContractType {get; set;}
        public DateTime CreationDate {get; set;}
        public string? Location {get; set;}

        public int CompanyId {get; set;}
        public string? CompanyName {get; set; }  

        public List<ApplicationsDTO>? Applications {get; set; }
    }

}