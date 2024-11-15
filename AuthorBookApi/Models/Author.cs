using System.ComponentModel.DataAnnotations;

namespace AuthorBookApi.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Book>? Books { get; set; }

        public AuthorDetail? AuthorDetail { get; set; }
    }
}
