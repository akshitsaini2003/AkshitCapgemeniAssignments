using System.ComponentModel.DataAnnotations;

namespace MVCExampleDemo.Models
{
    public class Dog
    {
        [Required(ErrorMessage ="ID is Required")]
        public int ID {  get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(222)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        [Range(0,20,ErrorMessage ="Age should be between 0 and 20 only")]
        public int Age {  get; set; }
    }
}
