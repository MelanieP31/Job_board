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

        public UserDTO? User {get; set; }

        public List<ApplicationsCollection>? appCollection {get; set; }
    }

    public class ApplicationsCollection {
        public int appId { get; set; }
        public DateTime? ApplicationTime {get; set; }
        public string? Status {get; set; }
        public string? Message {get; set; }
    }

}