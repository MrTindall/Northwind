using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Controllers
{
    public class CustomerController(DataContext db) : Controller
    {
        private readonly DataContext _dataContext = db; 

        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCustomer(int id, Customer customer)
        {
            customer.CustomerId = id;
            if (ModelState.IsValid) {
                _dataContext.AddCustomer(customer);
                return RedirectToAction("Register");
            }
            @ViewBag.CustomerId = id;
            return View();
        }

        public IActionResult Index() => View(_dataContext.Customers);
    }
}