using Microsoft.AspNetCore.Mvc;
using WaggyProjectAcunmedya.Context;

namespace WaggyProjectAcunmedya.ViewComponents
{
    [ViewComponent(Name = "DefaultBanner")]
    public class DefaultBannerComponent : ViewComponent
    {
        private readonly WaggyContext _context;

        public DefaultBannerComponent(WaggyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Banners.ToList();
            return View(values);
        }
    }
}
