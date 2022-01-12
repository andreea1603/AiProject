namespace DomainLayer.Models
{
    public class Post:BaseEntity
    {
        public string content { get; set; }
        public string sentiment { get; set; }
    }
}
