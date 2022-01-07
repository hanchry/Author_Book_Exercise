using System.ComponentModel.DataAnnotations;

namespace AuthorAPI.Models
{
    public class Book
    {
        [Key]
        public int ISBN { get; set; }
        [Required, MaxLength(40)]
        public string Tittle { get; set; }
        public int PublicationYear { get; set; }
        public int NumberOfPages { get; set; }
        public string Genre { get; set; }
    }
}