using Hotel_Management.Areas.Booking.Models;
using Hotel_Management.Areas.Room.Models;
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.Booking.Controllers
{
    [Area("Booking")]
    public class LOC_UserSideBookingController : Controller
    {
        public IActionResult UserSideBookingView(int RoomID)
        {
            Room_DALBase dal = new Room_DALBase();
            LOC_RoomModel roommodel = dal.MST_Room_SelectByRoomID(RoomID);
            LOC_BookingModel model = new LOC_BookingModel();
            model.RoomID = roommodel.RoomID;
            model.AdultCapacity = roommodel.AdultCapacity;
            model.ChildCapacity = roommodel.ChildCapacity;
            model.TypeName = roommodel.TypeName;
            model.RoomImage = roommodel.RoomImage;
            return View(model);
        }
        public IActionResult BookingDetail()
        {
            
            Booking_DALBase dALBase = new Booking_DALBase();
            return View(dALBase.MST_Booking_SelectAll());
        }
        public IActionResult SaveForAddEditUser(LOC_BookingModel model)
        {
            if (model.BookingID != 0)
            {
                if (model.IdProofFile == null && TempData["IdProofphoto"] != null)
                {
                    model.IdProofphoto = TempData["IdProofphoto"].ToString();
                }
            }
            if (model.IdProofFile != null)
            {
                string filePath =
               System.IO.Path.GetExtension(model.IdProofFile.FileName);

                string directoryPath = @"D:\Semester-6\Project\Hotel_Management\Hotel_Management\wwwroot\Images";

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string folderPath = Path.Combine("wwwroot/Images/", model.IdProofFile.FileName);
                using (FileStream fs = System.IO.File.Create(folderPath))
                {
                    model.IdProofFile.CopyTo(fs);
                }
                model.IdProofphoto = "/Images/" + model.IdProofFile.FileName;
            }
            bool ans = false;

            Booking_DALBase dal = new Booking_DALBase();
            if (model.BookingID == null)
            {
                ans = dal.MST_Booking_Add(model);
            }
            if (ans)
            {
                return RedirectToAction("BookingDetail");
            }
            else
            {
                return RedirectToAction("UserSideBookingView");
            }
        }
        public IActionResult UserDeleteByBookingID(int BookingID)
        {
            try
            {
                Booking_DALBase dal = new Booking_DALBase();
                bool deleted = dal.MST_Booking_DeleteByBookingID(BookingID);
            }
            catch { }
            return RedirectToAction("BookingDetail");
        }

    }
}
