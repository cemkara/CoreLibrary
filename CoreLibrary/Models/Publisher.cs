using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreLibrary.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
       
        [Required(ErrorMessage = "name cannot be blank")]
        [MaxLength(50, ErrorMessage = "please enter name between 5-50 characters")]
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
