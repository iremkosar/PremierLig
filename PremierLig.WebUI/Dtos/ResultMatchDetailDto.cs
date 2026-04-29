namespace PremierLig.WebUI.Dtos
{
    public class ResultMatchDetailDto
    {
        public int MatchDetailId { get; set; }
        public int FixtureId { get; set; }
        public int Minute { get; set; }
        public string ActionType { get; set; }
        public string Description { get; set; }
        public int TeamId { get; set; }
    }
}
