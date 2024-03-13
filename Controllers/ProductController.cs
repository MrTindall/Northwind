using Microsoft.AspNetCore.Mvc;

namespace Northwind.Controllers
{
    public class ProductController(DataContext db) : Controller
    {
        private readonly DataContext _dataContext = db;


        public IActionResult Category() {
            return View(_dataContext.Categories.OrderBy(c => c.CategoryName));
        }

        public IActionResult Index(int id) => View(_dataContext.Products
                                            .Where(p => p.CategoryId == id)
                                            .Where(p => p.UnitsInStock != 0));
    }
}