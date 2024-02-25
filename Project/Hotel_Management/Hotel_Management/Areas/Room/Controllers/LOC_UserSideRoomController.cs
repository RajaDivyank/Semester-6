using Hotel_Management.Areas.Booking.Models;
using Hotel_Management.Areas.Room.Models;
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace Hotel_Management.Areas.Room.Controllers
{
    [Area("Room")]
    public class LOC_UserSideRoomController : Controller
    {
        #region Method 1 :- Room View
        public IActionResult UserSideRoomView()
        {
            BookingModel model = JsonConvert.DeserializeObject<BookingModel>(TempData["model1"].ToString());
            Room_DALBase bal = new Room_DALBase();
            return View(bal.MST_Room_SelectAll());
        }

        #endregion
        #region Method 2 :- Room Detail
        public IActionResult RoomDetail(int RoomID)
        {
            Room_DALBase dal = new Room_DALBase();
            LOC_RoomModel model = dal.MST_Room_SelectByRoomID(RoomID);
            return View(model);
        }
        #endregion
    }
}
