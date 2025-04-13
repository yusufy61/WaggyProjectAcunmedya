using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using WaggyProjectAcunmedya.Context;
using WaggyProjectAcunmedya.Entities;

namespace WaggyProjectAcunmedya.Controllers
{
    public class DefaultController : Controller
    {
        private readonly WaggyContext _context;
        public DefaultController(WaggyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
