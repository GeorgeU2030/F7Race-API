namespace f7Race_API.Models {
    public class SeasonRace {
        public int SeasonRaceId { get; set; }
        public required int SeasonId { get; set; }
        public string? Name { get; set; }
        public string? FlagRace { get; set; }
        public int Laps { get; set; }
        public string? ImageCircuit { get; set; }
        public int FirstPosition { get; set; }
        public int SecondPosition { get; set; }
        public int ThirdPosition { get; set; }
        public int FourthPosition { get; set; }
        public int FifthPosition { get; set; }
        public int SixthPosition { get; set; }
        public int SeventhPosition { get; set; }
        public int EighthPosition { get; set; }
        public int NinthPosition { get; set; }
        public int TenthPosition { get; set; }
        
    }
}