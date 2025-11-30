using Microsoft.AspNetCore.Mvc;

namespace WaggyProjectAcunmedya.ViewComponents
{
    [ViewComponent(Name = "DefaultSendMessage")]
    public class DefaultSendMessageComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}