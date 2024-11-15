using AuthorBookApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorBookApi.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
    }
}
