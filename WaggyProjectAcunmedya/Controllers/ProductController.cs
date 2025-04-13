using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WaggyProjectAcunmedya.Context;
using WaggyProjectAcunmedya.Entities;

namespace WaggyProjectAcunmedya.Controllers
{
    //[Authorize]
    public class ProductController : Controller
    {
        private readonly WaggyContext _dbcontext;

        public ProductController(WaggyContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            var products = _dbcontext.Products.Include(x => x.Category).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            var categoryList = _dbcontext.Categories.ToList();
            ViewBag.Categories = (from x in categoryList
                                  select new SelectListItem
                                  {
                                      Text = x.CategoryName,
                                      Value = x.CategoryId.ToString()
                                  }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            _dbcontext.Products.Add(product);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await _dbcontext.Products.FindAsync(id);
            if (product == null)
            {
                return BadRequest();
            }

            var categoryList = await _dbcontext.Categories.ToListAsync();
            ViewBag.Categories = (from x in categoryList
                                  select new SelectListItem
                                  {
                                      Text = x.CategoryName,
                                      Value = x.CategoryId.ToString()
                                  });
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            _dbcontext.Products.Update(product);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _dbcontext.Products.FindAsync(id);
            if (product == null)
            {
                return BadRequest();
            }
            _dbcontext.Products.Remove(product);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
