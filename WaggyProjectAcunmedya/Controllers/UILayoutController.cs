using Microsoft.AspNetCore.Mvc;

namespace WaggyProjectAcunmedya.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
