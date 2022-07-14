using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCityApi.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public string PublicationTime { get; set; }
    }
}
