namespace backend.DTO
{
    public class FormationsDTO{
        public int FormationId {get; set; }
        public string? Institution {get; set; }
        public string? Name {get; set; }
        public DateTime? StartDate {get; set; }
        public DateTime? EndDate {get; set; }
        public string? Description {get; set; }
        
        public int UserId {get; set; }
        public string? UserName {get; set; }
        public string? UserEmail {get; set; }

    }
}