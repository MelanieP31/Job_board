using backend.Models;

namespace backend.DTO
{
    public class UserCompetenciesDTO{

        public int UserId {get; set; }
        public int CompetencyId {get; set; }
        public string? CompetencyName {get; set; }
    }
}