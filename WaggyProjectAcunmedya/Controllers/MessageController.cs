using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WaggyProjectAcunmedya.Context;

namespace WaggyProjectAcunmedya.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly WaggyContext _context;

        public MessageController(WaggyContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var messages =  await _context.Messages.ToListAsync();
            return View(messages);
        }

        /// <summary>
        /// mesajı okundu olarak işaretler
        /// ne zaman kullanılır: Mesaj okunduğunda bu metot çağrılır
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ChangeIsReadToTrue(int id)
        {
            var message =  _context.Messages.Find(id);
            if (message == null)
            {
                return NotFound();
            }
            message.IsRead = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Mesajı okunmadı olarak işaretler
        /// Ne zaman kullanılır: Yanlışlıkla okundu olarak işaretlenen mesajları düzeltmek için
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ChangeIsReadToFalse(int id)
        {
            var message =  _context.Messages.Find(id);
            if (message == null)
            {
                return NotFound();
            }
            message.IsRead = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> MessageDetails(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }
    }
}
