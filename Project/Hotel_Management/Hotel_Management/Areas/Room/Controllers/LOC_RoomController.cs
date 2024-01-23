using Hotel_Management.BAL;
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.Room.Controllers
{
    public class LOC_RoomController : Controller
    {
        public IActionResult RoomView()
        {
            Room_DALBase bal = new Room_DALBase();
            return View(bal.MST_Room_SelectAll());
        }
    }
}
