using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Servise()
        {
            return View();
        }
    }
}
