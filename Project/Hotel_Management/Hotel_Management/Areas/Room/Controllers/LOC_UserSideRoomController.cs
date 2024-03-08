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
            Room_DALBase dal = new Room_DALBase();
            var room_dal = dal.MST_Room_SelectAll();
            if (Convert.ToBoolean(TempData["form"]))
            {
                BookingModel model = JsonConvert.DeserializeObject<BookingModel>(TempData["model1"].ToString());
                var vModel = new Tuple<BookingModel, List<LOC_RoomModel>>(model, room_dal);
                return View(vModel);
            }
            else
            {
                BookingModel model = new BookingModel();
                var vModel = new Tuple<BookingModel, List<LOC_RoomModel>>(model, room_dal);
                return View(vModel);
            }
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
        #region Method 3 :- Room Filter
        public IActionResult RoomSearch(int Child, int Adult)
        {
            Room_DALBase dal = new Room_DALBase();
            BookingModel model = new BookingModel();
            if (Child != 0 || Adult != 0)
            {
                var room_dal = dal.RoomFilter(Child, Adult);
                var vModel = new Tuple<BookingModel, List<LOC_RoomModel>>(model, room_dal);
                return View("UserSideRoomView", vModel);
            }
            else
            {
                var room_dal = dal.MST_Room_SelectAll();
                var vModel = new Tuple<BookingModel, List<LOC_RoomModel>>(model, room_dal);
                return View("UserSideRoomView", vModel);
            }
        }
        #endregion
    }
}
