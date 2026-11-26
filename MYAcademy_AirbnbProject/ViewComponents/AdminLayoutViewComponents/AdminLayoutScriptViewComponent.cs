using Microsoft.AspNetCore.Mvc;

namespace MYAcademy_AirbnbProject.ViewComponents.AdminLayoutViewComponents
{
    public class AdminLayoutScriptViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
