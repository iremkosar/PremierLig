namespace PremierLig.WebUI.Dtos
{
    public class UpdateTeamDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string ShortName { get; set; }
        public string LogoUrl { get; set; }
        public string StadiumName { get; set; }
        public string City { get; set; }
    }
}
