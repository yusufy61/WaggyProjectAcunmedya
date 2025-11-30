using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaggyProjectAcunmedya.Context;
using WaggyProjectAcunmedya.Entities;

namespace WaggyProjectAcunmedya.Controllers
{
    [Authorize]
    public class TestimonialController : Controller
    {
        private readonly WaggyContext _context;

        public TestimonialController(WaggyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var testimonials = await _context.Testimonials.ToListAsync();
            return View(testimonials);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(Testimonial testimonial)
        {
            // eğer ki model tam gönderilmemişse aynı sayfa üzerinden geri gönderiyoruz.
            if(!ModelState.IsValid)
            {
                return View(testimonial);
            }

            _context.Testimonials.Add(testimonial);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if(testimonial == null)
            {
                return NotFound();
            }
            return View(testimonial);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(Testimonial testimonial)
        {
            // eğer ki model tam gönderilmemişse aynı sayfa üzerinden geri gönderiyoruz.
            if (!ModelState.IsValid)
            {
                return View(testimonial);
            }
            _context.Testimonials.Update(testimonial);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            _context.Testimonials.Remove(testimonial);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
