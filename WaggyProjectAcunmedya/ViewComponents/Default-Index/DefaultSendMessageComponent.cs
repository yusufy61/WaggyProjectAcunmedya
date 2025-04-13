using Microsoft.AspNetCore.Mvc;

namespace WaggyProjectAcunmedya.ViewComponents.Default_Index
{
    public class DefaultSendMessageComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
