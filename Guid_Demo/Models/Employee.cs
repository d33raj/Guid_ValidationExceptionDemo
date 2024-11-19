using System.ComponentModel.DataAnnotations;

namespace Guid_Demo.Models
{
    public class Employee
    {
        [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage ="Name is a Requied Field!")]
        [StringLength(25,ErrorMessage ="Name should be less than 25!")]
        public string Name { get; set; }


        [Required(ErrorMessage ="Email is a Required Field!")]
        [EmailAddress]
        public string Email { get; set; }

    }
}
