namespace SmartCityApi.Models
{
    public class News
    {
        public int Id { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Publisher { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string? Image { get; set; }
        
    }
}
