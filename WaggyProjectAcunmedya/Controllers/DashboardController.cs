using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaggyProjectAcunmedya.Context;

namespace WaggyProjectAcunmedya.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly WaggyContext _context;

        public DashboardController(WaggyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Verileri Dashboarda göstermek için ViewModel yerine viewbag ile ekrana göstereceğiz.
            ViewBag.TotalProducts = await _context.Products.CountAsync();
            ViewBag.TotalCategories = await _context.Categories.CountAsync();
            ViewBag.TotalMessages = await _context.Messages.CountAsync();
            ViewBag.TotalTestimonials = await _context.Testimonials.CountAsync();

            ViewBag.CategoryLabels = await _context.Categories.Select(c => c.CategoryName).ToListAsync();
            ViewBag.CategoryCounts = await _context.Categories.Select(c => c.Products.Count).ToListAsync();

            // Örnek veri: Ay isimleri ve aylık ürün sayıları
            ViewBag.MonthLabels = new string[]
            {
                "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran"
            };

            ViewBag.MonthlyProductCounts = new int[]
            {
                1, 2, 3, 4, 5, 6
            };

            return View();
        }
    }
}
