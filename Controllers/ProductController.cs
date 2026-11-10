using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuchanh3.Models;

namespace thuchanh3.Controllers
{
    public class ProductController : Controller
    {
        //GIA LAP CSDL
        public static List<Product> products = new List<Product>()
        {
            new Product() {Id = 1, Name = "Laptop Dell", Price = 1000, Description = "Laptop Dell ", CategoryId = "1"},
            new Product() {Id = 2, Name = "Iphone 14 promax", Price = 800, Description = "Iphone 14 Pro Max", CategoryId = "2"},
            new Product() {Id = 3, Name = "Samsung Galaxys26", Price = 500, Description = "Samsung Galaxy s26", CategoryId = "3"},
        };
        // GET: ProductController
        public ActionResult Index(string? searchString)
        {
            var products = Data.Products.AsQueryable();
            if(!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString, StringComparison.Ordinal));
            }
            return View(products.Select(ToViewModel).ToList());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if(existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            return RedirectToAction(nameof(Index));
        },

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }
            products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
        private static ProductViewModel ToViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryName = DataSeeds.categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name ?? string.Empty
            };
        }

        public string GetDatapath(string file) => $"Data\\{file}";

        public void Upload(Book book, IFormFile file)
        {
            if(file != null)
            {
                var path = GetDatapath(file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    book.DataFile = file.FileName;
                }
            }
        }
            };
        }
    
        
    

