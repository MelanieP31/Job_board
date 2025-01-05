using System.Text.Json.Serialization;

namespace backend.DTO
{
    public class ExperiencesDTO{
         public int ExperienceId {get; set; }
        public string? CompanyName {get; set; }
        public string? Title {get; set; }
        public DateTime? StartDate {get; set;}
        public DateTime? EndDate {get; set; }
        public string? Description {get; set; }

        [JsonIgnore]
        public int UserId {get; set; }
        [JsonIgnore]
        public string? UserName {get; set; }
        [JsonIgnore]        
        public string? UserEmail {get; set; }

    }
}