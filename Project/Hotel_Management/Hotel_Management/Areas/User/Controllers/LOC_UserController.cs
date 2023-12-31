using Hotel_Management.Areas.User.Models;
using Hotel_Management.BAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.User.Controllers
{
    [Area("User")]
    public class LOC_UserController : Controller
    {
        public IActionResult UsersView()
        {
            User_BALBase bal = new User_BALBase();
            return View(bal.MST_Users_SelectAll());
        }
    }
}
