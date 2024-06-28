namespace f7Race_API.Models {
    public class SeasonBrand {
        public int SeasonBrandId { get; set; }
        public required int SeasonId { get; set; }
        public required string Name { get; set;}
        public required string Logo { get; set; }
        public required string Country { get; set; }
        public required string Flag { get; set; }
        public int Points { get; set; }
    }
}