namespace backend.DTO
{
    public class ExperiencesDTO{
         public int ExperienceId {get; set; }
        public string? CompanyName {get; set; }
        public string? Title {get; set; }
        public DateTime? StartDate {get; set;}
        public DateTime? EndDate {get; set; }
        public string? Description {get; set; }

        public int UserId {get; set; }
        public string? UserName {get; set; }
        public string? UserEmail {get; set; }

    }
}