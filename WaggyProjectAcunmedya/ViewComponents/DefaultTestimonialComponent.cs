using Microsoft.AspNetCore.Mvc;
using WaggyProjectAcunmedya.Context;

namespace WaggyProjectAcunmedya.ViewComponents
{
    [ViewComponent(Name = "DefaultTestimonial")]
    public class DefaultTestimonialComponent : ViewComponent
    {
        private readonly WaggyContext _context;

        public DefaultTestimonialComponent(WaggyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Testimonials.ToList();
            return View(values);
        }
    }
}
