using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codeFirstApproach.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description Is Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Age Is Required")]
        public int? Age { get; set; }
        [Required(ErrorMessage = "Standard Is Required")]
        public int? Standard { get; set; }


    }
}
