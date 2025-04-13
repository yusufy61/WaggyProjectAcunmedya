using Microsoft.AspNetCore.Mvc;
using WaggyProjectAcunmedya.Context;

namespace WaggyProjectAcunmedya.ViewComponents.Default_Index
{
    public class DefaultCategoriesViewComponent : ViewComponent
    {
        private readonly WaggyContext _context;
        public DefaultCategoriesViewComponent(WaggyContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
    }
}
