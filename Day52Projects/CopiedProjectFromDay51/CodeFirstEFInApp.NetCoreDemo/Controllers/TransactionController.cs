using CodeFirstEFInApp.NetCoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFInApp.NetCoreDemo.Controllers
{
    public class TransactionController : Controller
    {
        private readonly EventContext context;

        public TransactionController(EventContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            ModelState.Clear();
            ModelState.Remove(nameof(Customer.CustomerID));
            if (ModelState.IsValid)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("CreateProduct", new {customerId=customer.CustomerID});
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult DisplayCustomers()
        {
            var customers = context.Customers.ToList();
            return View(customers);
        }

        public IActionResult CreateProduct(int? customerId)
        {
            var cid = customerId ?? 0;
            ViewBag.CustomerID = cid;
            ViewBag.CustomerList=new SelectList(context.Customers,"CustomerID","CustomerName",cid);
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            ModelState.Clear();
            ModelState.Remove(nameof(Product.ProductID));
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("CreateProduct", new { productId = product.CustomerID });
            }

            ViewBag.CustomerID = product.CustomerID;
            ViewBag.CustomerList = new SelectList(context.Customers, "CustomerID", "CustomerName", product.CustomerID);
            return View(product);
        }


        public IActionResult Summary(int customerId)
        {
            var customer = context.Customers
                .Include(c => c.Products)
                .FirstOrDefault(c => c.CustomerID == customerId);

            if (customer == null || !customer.Products.Any())
            {
                return RedirectToAction("CreateProduct", new { customerId });
            }

            return View(customer);
        }
    }
}
