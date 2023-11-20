using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.TestimonialsComponents;

public class CounterViewComponent : ViewComponent
{
    
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}