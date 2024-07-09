namespace f7Race_API.Models {
public class SeasonRaceresponse {
    public int SeasonRaceId { get; set; }
    public int SeasonId { get; set; }
    public string? Name { get; set; }
    public string? FlagRace { get; set; }
    public int Laps { get; set; }
    public string? ImageCircuit { get; set; }
    public SeasonBrand? FirstPosition { get; set; }
    public SeasonBrand? SecondPosition { get; set; }
    public SeasonBrand? ThirdPosition { get; set; }
    public SeasonBrand? FourthPosition { get; set; }
    public SeasonBrand? FifthPosition { get; set; }
    public SeasonBrand? SixthPosition { get; set; }
    public SeasonBrand? SeventhPosition { get; set; }
    public SeasonBrand? EighthPosition { get; set; }
    public SeasonBrand? NinthPosition { get; set; }
    public SeasonBrand? TenthPosition { get; set; }
}
}