using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.Contact.Controllers
{
    public class LOC_ContactController : Controller
    {
        public IActionResult ContactView()
        {
            return View();
        }
    }
}
