using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaggyProjectAcunmedya.Context;


namespace WaggyProjectAcunmedya.ViewComponents
{
    public class _MessagesDropdownComponentPartial : ViewComponent
    {
        private readonly WaggyContext _context;

        public _MessagesDropdownComponentPartial(WaggyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _context.Messages
         .Where(x => !x.IsRead)  // sadece okunmamışlar
         .OrderByDescending(x => x.MessageId)
         .Take(4)
         .ToListAsync();

            return View(values);
        }
    }
}
