namespace BaltaDataAccess.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public String? Title { get; set; }
        public String? Url { get; set; }
        public String? Summary { get; set; }
        public int Order { get; set; }
        public String? Description { get; set; }
        public bool Featured { get; set; }
    }
}