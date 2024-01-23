using Microsoft.AspNetCore.Mvc;

namespace APIConsume.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult PersonView()
        {
            return View();
        }
    }
}
