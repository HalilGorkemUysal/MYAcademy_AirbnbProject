using Microsoft.AspNetCore.Mvc;

namespace MYAcademy_AirbnbProject.ViewComponents.CategoryViewComponents
{
    public class CreateCategoryStyleViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}