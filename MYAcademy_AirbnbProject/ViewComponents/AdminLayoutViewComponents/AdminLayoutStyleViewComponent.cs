using Microsoft.AspNetCore.Mvc;

namespace MYAcademy_AirbnbProject.ViewComponents.AdminLayoutViewComponents
{
    public class AdminLayoutStyleViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
