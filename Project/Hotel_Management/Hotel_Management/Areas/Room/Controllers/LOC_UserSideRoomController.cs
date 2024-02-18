using Hotel_Management.Areas.Booking.Models;
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.Room.Controllers
{
    [Area("Room")]
    public class LOC_UserSideRoomController : Controller
    {
        #region User_side_RoomView
        public IActionResult UserSideRoomView()
        {
            Room_DALBase bal = new Room_DALBase();
            return View(bal.MST_Room_SelectAll());
        }
        
        #endregion
    }
}
