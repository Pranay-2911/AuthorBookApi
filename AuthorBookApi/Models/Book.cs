using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorBookApi.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime PublishedDate { get; set; }

        public Author? Author { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
    }
}
