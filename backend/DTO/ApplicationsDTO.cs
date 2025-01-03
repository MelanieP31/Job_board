namespace backend.DTO
{
    public class ApplicationsDTO {
        public int AppId {get; set;}
        public DateTime? AppDate {get; set;} = DateTime.Now;
        public string? Message {get; set;}
        public string Status {get; set;} = "in progress";

        public int JobId {get; set; }
        public string? JobTitle {get; set;}

        public UserDTO? User {get; set; }

    }
}