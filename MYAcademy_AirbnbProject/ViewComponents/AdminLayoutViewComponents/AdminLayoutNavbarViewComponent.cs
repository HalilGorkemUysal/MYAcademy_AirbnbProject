using Microsoft.AspNetCore.Mvc;

namespace MYAcademy_AirbnbProject.ViewComponents.AdminLayoutViewComponents
{
    public class AdminLayoutNavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
