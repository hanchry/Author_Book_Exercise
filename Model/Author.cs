using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(15)]
        public string FirsName { get; set; }
        [Required, MaxLength(15)]
        public string LastName { get; set; }
        public IList<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }
    }
}