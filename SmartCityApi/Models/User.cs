namespace SmartCityApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string? Description { get; set; }
        public string? ProfileImage { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public List<Category>? Categories { get; set; } = new List<Category>();
        public List<Event>? Events { get; set; } = new List<Event>();
        public List<Team>? Teams { get; set; } = new List<Team>();
    }
}
