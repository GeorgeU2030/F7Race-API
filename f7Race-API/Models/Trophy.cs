namespace f7Race_API.Models {
    public class Trophy {
        public int TrophyId { get; set; }
        public int RaceId { get; set; }
        public Race? Race { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}