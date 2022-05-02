using System.ComponentModel.DataAnnotations;

namespace CoreLibrary.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "name cannot be blank")]
        [MaxLength(100, ErrorMessage = "please enter name maximum 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "name cannot be blank")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "name cannot be blank")]
        public int Stock { get; set; }
        public bool Status { get; set; }
        public string ImageUrl{ get; set; }


        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public int WriterId { get; set; }
        public Writer Writer { get; set; }
    }
}
