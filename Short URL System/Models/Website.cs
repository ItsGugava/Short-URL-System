namespace Short_URL_System.Models
{
    public class Website
    {
        public int Id { get; set; }
        public string ShortText { get; set; }
        public string URL { get; set; }
        public int VisitCount { get; set; } = 0;
    }
}
