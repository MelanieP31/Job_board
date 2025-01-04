using System.Text.Json.Serialization;

namespace backend.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public string? City { get; set; }
        public DateTime? CreationDate { get; set; }

        [JsonIgnore]
        public List<ApplicationsDTO>? AppCollection { get; set; }
        public List<UserCompetenciesDTO>? UserCompetencies { get; set; }
        public List<FormationsDTO>? Formations { get; set; }
        public List<ExperiencesDTO>? Experiences { get; set; }
    }

}