using System.ComponentModel.DataAnnotations;

namespace DbFirstEFInAsp.NetCoreDemo.Models.NorthWindViewModels
{
    public class SpainCustomerViewModel
    {
        [Key]
        public string custId { get; set; }
        public string custContName {  get; set; }
        public string custCompName { get; set; }
    }
}
