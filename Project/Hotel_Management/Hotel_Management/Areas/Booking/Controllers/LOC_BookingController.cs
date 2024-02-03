using Hotel_Management.Areas.Booking.Models;
using Hotel_Management.Areas.Role.Models;
using Hotel_Management.Areas.Room.Models;
using Hotel_Management.BAL;
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.Booking.Controllers
{
    [Area("Booking")]
    public class LOC_BookingController : Controller
    {
        #region Admin Side
        #region MST_Booking_SelectAll
        public IActionResult BookingView()
        {
            Booking_DALBase dal = new Booking_DALBase();
            return View(dal.MST_Booking_SelectAll());
        }
        #endregion
        #region MST_Booking_DeleteByBookingID
        public IActionResult DeleteByBookingID(int BookingID)
        {
            try
            {
                Booking_DALBase dal = new Booking_DALBase();
                bool deleted = dal.MST_Booking_DeleteByBookingID(BookingID);
            }
            catch { }
            return RedirectToAction("BookingView");
        }
        #endregion
        #region MST_Booking_SelectByBookingID
        public IActionResult BookingDetail(int BookingID)
        {
            Booking_DALBase dal = new Booking_DALBase();
            LOC_BookingModel model = dal.MST_Booking_SelectByBookingID(BookingID);
            return View(model);
        }
        #endregion
        #region MST_Booking_AddEdit
        public IActionResult BookingAddEdit(int BookingID)
        {
            if (BookingID == null)
            {
                return View();
            }
            else
            {
                Booking_DALBase dal = new Booking_DALBase();
                LOC_BookingModel model = dal.MST_Booking_SelectByBookingID(BookingID);
                return View(model);
            }
        }
        #endregion
        #region SaveForAddEdit
        public IActionResult SaveForAddEdit(LOC_BookingModel model)
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
            if (model.BookingID != null)
            {
                ans = dal.MST_Booking_Update(model);
            }
            else
            {
                ans = dal.MST_Booking_Add(model);
            }
            if (ans)
            {
                return RedirectToAction("BookingView");
            }
            else
            {
                return RedirectToAction("BookingView");
            }
        }
        #endregion
        #endregion
        #region User Side
        #region MST_UserSideBookingView
        public IActionResult UserSideBookingView()
        {
            return View();
        }
        #endregion
        #endregion
    }
}
