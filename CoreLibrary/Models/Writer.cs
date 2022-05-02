using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreLibrary.Models
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }

        [Required(ErrorMessage = "name cannot be blank")]
        [MaxLength(100, ErrorMessage = "please enter name maximum 100 characters")]
        public string Name { get; set; }

        public List<Book> Books { get; set; }

    }
}
