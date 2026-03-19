using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEFInApp.NetCoreDemo.Models
{
    public class Product
    {
        public int ProductID {  get; set; }
        [Required]
        public string ProductName { get; set; }

        [Display(Name ="Who Buyed")]
        [ForeignKey("Customer")]
        public int CustomerID {  get; set; }
        public Customer Customer { get; set; }
    }
}
