using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaggyProjectAcunmedya.Context;
using WaggyProjectAcunmedya.Entities;

namespace WaggyProjectAcunmedya.Controllers
{
    [Authorize]
    public class BannerController : Controller
    {
        private readonly WaggyContext _context;

        public BannerController(WaggyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _context.Banners.ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(Banner banner)
        {
            // Eğer model doğrulaması başarısızsa aynı view sayfasına veriler ile geri dön
            

            _context.Banners.Add(banner);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(Banner banner)
        {
            // Eğer model doğrulaması başarısızsa aynı view sayfasına veriler ile geri dön
            if (!ModelState.IsValid)
            {
                return View(banner);
            }
            _context.Banners.Update(banner);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            _context.Banners.Remove(banner);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
