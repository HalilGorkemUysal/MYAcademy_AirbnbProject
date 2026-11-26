using Microsoft.AspNetCore.Mvc;

namespace MYAcademy_AirbnbProject.ViewComponents.AdminLayoutViewComponents
{
    public class AdminLayoutHeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
