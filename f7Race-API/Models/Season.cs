namespace f7Race_API.Models {
    public class Season {
        public int SeasonId { get; set; }
        public required int Edition { get; set; }
        public int? WinnerId { get; set; }
        public Brand? Winner { get; set; }
        public int? SecondId { get; set; }
        public Brand? Second { get; set; }
        public int? ThirdId { get; set; }
        public Brand? Third { get; set; }

        // Relation with Race and Brands
        public ICollection<SeasonRace> Races { get; set; } = [];
        public ICollection<SeasonBrand> Brands { get; set; } = [];

        // Relation with User
        public int UserId { get; set; }
    }
}