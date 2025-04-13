using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaggyProjectAcunmedya.Context;

namespace WaggyProjectAcunmedya.ViewComponents.Default_Index
{
    public class DefaultProductComponent : ViewComponent
    {
        private readonly WaggyContext _context;
        public DefaultProductComponent(WaggyContext context)
        {
           _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Categories.Include(x => x.Products).ToList();

            return View(values);
        }
    }
}
