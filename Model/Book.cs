using System.ComponentModel.DataAnnotations;

namespace Model
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
        //public Author Author { get; set; }
    }
}