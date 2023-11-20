using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.FooterComponents;

public class FooterLayoutViewComponents : ViewComponent
{
    
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}