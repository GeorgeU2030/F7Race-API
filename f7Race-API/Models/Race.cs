namespace f7Race_API.Models {
    public class Race {
        public int RaceId { get; set;}
        public required string Name { get; set; }
        public string? FlagRace { get; set; }
        public int Laps { get; set; }
        public string? ImageCircuit { get; set; }

        // Relation with the User
        public int UserId { get; set; } 
    }
}