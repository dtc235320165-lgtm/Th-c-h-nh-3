using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuchanh3.Models;

namespace thuchanh3.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        public static List<Category> categories = new List<Category>()
            {
            new Category() { Id = 1, Name = "Laptop" },
            new Category() { Id = 2, Name = "Smartphone" },
            new Category() { Id = 3, Name = "Phụ kiện" },
        };
        public CategoryController(ILogger<CategoryController> logger)
        {
             _logger = logger;
        }
        // GET: CategoryController
        [HttpGet]
        public ActionResult Index()
        {
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
               
                category.Id = categories.Count + 1;
                categories.Add(category);
                    return RedirectToAction(nameof(Index));
                }
                return View(category);

        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var Editcategory = categories.FirstOrDefault(c => c.Id == id);
            if (Editcategory == null)
            {
                return NotFound();
            }
            return View(Editcategory);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            var existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.Name = category.Name;
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed (int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            categories.Remove(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
