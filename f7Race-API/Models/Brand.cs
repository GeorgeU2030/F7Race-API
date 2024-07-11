using System.ComponentModel.DataAnnotations.Schema;
using f7Race_API.Models.DTOS;

namespace f7Race_API.Models {
    public class Brand {
        public int BrandId { get; set; }
        public required string Name { get; set; }
        public required string Logo { get; set; }
        public required string Country { get; set; }
        public required string Flag { get; set; }
        public int TotalWins { get; set; } = 0;
        public int TotalPodiums { get; set; } = 0;
        public int TotalPoints { get; set; } = 0;
        public int TotalChampions { get; set; } = 0;

        // Relation with the User
        public int UserId { get; set; }

        // Relation with Trophies
        public ICollection<Trophy> Trophies { get; set; } = [];

        [NotMapped]
        public ICollection<TrophyCountDto> TrophiesCount { get; set; } = [];
    }
}