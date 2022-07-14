namespace SmartCityApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int OrganizerId { get; set; }
        public Category Category { get; set; }
        public string EventDate { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string? Image { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
