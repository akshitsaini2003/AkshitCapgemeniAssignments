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

        public IActionResult CustomerOrderDetails(string id)
        {
            NorthWindContext cnt = new NorthWindContext();

            var orders = cnt.Orders
                .Where(o => o.CustomerId == id)
                .Select(o => new Order
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    RequiredDate = o.RequiredDate,
                    ShippedDate = o.ShippedDate
                }).ToList();

            ViewBag.CustomerId = id;

            return View(orders);
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

        public IActionResult ProductsInCategory(string categoryName)
        {
            NorthWindContext context =new NorthWindContext();
            var productsInCategory = context.Products.Where(x => x.Category.CategoryName==categoryName)
                .Select(x => new ProdCat
                {
                    prodname = x.ProductName,
                    catname = x.Category.CategoryName
                }).ToList();
            return View(productsInCategory);
        }

        public IActionResult OrderRange(string range)
        {
            NorthWindContext context = new NorthWindContext();
            var range1=Convert.ToInt32(range);
            var custOrderCount = context.Customers.Where(x => x.Orders.Count() > range1)
                .Select(x => new Customer
                {
                    CustomerId = x.CustomerId,
                    ContactName = x.ContactName
                });
            return View(custOrderCount);
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
