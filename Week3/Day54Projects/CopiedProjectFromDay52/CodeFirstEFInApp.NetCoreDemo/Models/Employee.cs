using System.ComponentModel.DataAnnotations;

namespace CodeFirstEFInApp.NetCoreDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter First Name")]
        public string FirstName {  get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email Address")]
        public string Email {  get; set; }
        [Required(ErrorMessage = "enter your age ")]
        [Range(0, 100, ErrorMessage = "please enter age between 1 to 100 only ")]
        public int Age { set; get; }
    }
}
