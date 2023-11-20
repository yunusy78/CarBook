using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.TestimonialsComponents;

public class TestimonialViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}