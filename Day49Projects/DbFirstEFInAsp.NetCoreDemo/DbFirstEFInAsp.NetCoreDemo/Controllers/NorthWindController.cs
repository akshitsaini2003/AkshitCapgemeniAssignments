using Microsoft.AspNetCore.Mvc;
using DbFirstEFInAsp.NetCoreDemo.Models;
using DbFirstEFInAsp.NetCoreDemo.Models.NorthWindViewModels;

namespace DbFirstEFInAsp.NetCoreDemo.Controllers
{
    public class NorthWindController : Controller
    {
        public IActionResult SpainCustomers()
        {
            NorthWindContext context = new NorthWindContext();

            var spainCustomers = context.Customers.Where(x => x.Country == "Spain").Select(x => new SpainCustomerViewModel
            {
                custId = x.CustomerId,
                custContName = x.ContactName,
                custCompName = x.CompanyName
            }).ToList();

            return View(spainCustomers);
        }


        public IActionResult searchCustomer(string contactName)
        {
            NorthWindContext context = new NorthWindContext();

            var searchCustomer = from customer in context.Customers
                                 where customer.ContactName == contactName
                                 select new SpainCustomerViewModel
                                 {
                                     custId = customer.CustomerId,
                                     custContName = customer.ContactName,
                                     custCompName = customer.CompanyName
                                 };
            return View(searchCustomer);
        }

        [HttpGet]
        public IActionResult EditCustomer(string id)
        {
            NorthWindContext context = new NorthWindContext();

            var editCustomer = context.Customers.Where(x => x.CustomerId==id).Select(x => new SpainCustomerViewModel
                            {
                                custId = x.CustomerId,
                                custContName = x.ContactName,
                                custCompName = x.CompanyName
                            }).FirstOrDefault();

            return View(editCustomer);
        }

        [HttpPost]
        public IActionResult EditCustomer(SpainCustomerViewModel model)
        {
            NorthWindContext context = new NorthWindContext();

            var customer = context.Customers.FirstOrDefault(x => x.CustomerId == model.custId);

            if (customer != null)
            {
                customer.ContactName = model.custContName;
                customer.CompanyName = model.custCompName;

                context.SaveChanges();
            }

            return RedirectToAction("SpainCustomers");
        }
    }
}
