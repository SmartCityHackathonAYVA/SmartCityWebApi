namespace SmartCityApi.Models
{
    public class News
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public string Title { get; set; }
        public string Text { get; set; }
        public string? Image { get; set; }
        public string PublicationTime { get; set; }
    }
}
