namespace f7Race_API.Models {
    public class Brand {
        public int BrandId { get; set; }
        public required string Name { get; set; }
        public required string Logo { get; set; }
        public required string Country { get; set; }
        public required string Flag { get; set; }
        public int TotalWins { get; set; }
        public int TotalPodiums { get; set; }
        public int TotalPoints { get; set; }

        // Relation with the User
        public int UserId { get; set; }
    }
}