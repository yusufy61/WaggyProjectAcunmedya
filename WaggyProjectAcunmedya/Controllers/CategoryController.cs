using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WaggyProjectAcunmedya.Context;
using WaggyProjectAcunmedya.Entities;

namespace WaggyProjectAcunmedya.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {

        private readonly WaggyContext _DbContext;
        public CategoryController(WaggyContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IActionResult Index()
        {
            var categories = _DbContext.Categories.ToList();
            return View(categories);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _DbContext.Categories.Add(category);
            _DbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = _DbContext.Categories.Find(id);
            _DbContext.Categories.Remove(category);
            await _DbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _DbContext.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            _DbContext.Update(category);
            await _DbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
