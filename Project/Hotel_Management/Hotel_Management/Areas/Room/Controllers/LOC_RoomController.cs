using Hotel_Management.Areas.Room.Models;
/*using Hotel_Management.BAL;*/
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Management.Areas.Room.Controllers
{
    [Area("Room")]
    public class LOC_RoomController : Controller
    {
        #region MST_Room_SelectAll
        public IActionResult RoomView()
        {
            Room_DALBase bal = new Room_DALBase();
            return View(bal.MST_Room_SelectAll());
        }
        #endregion
        #region MST_Room_DeleteByRoomID
        public IActionResult DeleteByRoomID(int RoomID)
        {
            try
            {
                TempData["Message"] = "Room Delete Successfully";
                Room_DALBase dal = new Room_DALBase();
                bool deleted = dal.MST_Room_DeleteByRoomID(RoomID);
            }
            catch { }
            return RedirectToAction("RoomView");
        }
        #endregion
        #region MST_Room_SelectByRoomID
        public IActionResult RoomDetail(int RoomID)
        {
            Room_DALBase dal = new Room_DALBase();
            LOC_RoomModel model = dal.MST_Room_SelectByRoomID(RoomID);
            return View(model);

        }
        #endregion
        #region MST_Room_AddEdit
        public IActionResult RoomAddEdit(int RoomID)
        {
            RoomStatus_DALBase status_DALBase = new RoomStatus_DALBase();
            RoomType_DALBase roomType_DALBase = new RoomType_DALBase();
            if (RoomID == null)
            {
                LOC_RoomModel model = new LOC_RoomModel();
                model.status = status_DALBase.MST_RoomStatus_SelectAll();
                model.typenames = roomType_DALBase.MST_RoomType_SelectAll();
                return View(model);
            }
            else
            {
                Room_DALBase dal = new Room_DALBase();
                LOC_RoomModel model = dal.MST_Room_SelectByRoomID(RoomID);
                model.status = status_DALBase.MST_RoomStatus_SelectAll();
                model.typenames = roomType_DALBase.MST_RoomType_SelectAll();
                TempData["RoomImage"] = model.RoomImage;
                TempData["Message"] = "Room Not Edit Successfully";
                return View(model);
            }
        }
        #endregion
        #region SaveForAddEdit
        public IActionResult SaveForAddEdit(LOC_RoomModel model)
        {
            if (model.RoomID != 0)
            {
                if (model.RoomImageFile == null && TempData["RoomImage"] != null)
                {
                    model.RoomImage = TempData["RoomImage"].ToString();
                }
            }
            if (model.RoomImageFile != null)
            {
                string filePath =
               System.IO.Path.GetExtension(model.RoomImageFile.FileName);

                string directoryPath = @"D:\Semester-6\Project\Hotel_Management\Hotel_Management\wwwroot\Images";

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string folderPath = Path.Combine("wwwroot/Images/", model.RoomImageFile.FileName);
                using (FileStream fs = System.IO.File.Create(folderPath))
                {
                    model.RoomImageFile.CopyTo(fs);
                }
                model.RoomImage = "/Images/" + model.RoomImageFile.FileName;
            }
            bool ans = false;

            Room_DALBase dal = new Room_DALBase();
            if (ModelState.IsValid)
            {
                if (model.RoomID != null)
                {
                    TempData["Message"] = "Room Edit Successfully";
                    ans = dal.MST_Room_Update(model);
                }
                else
                {
                    TempData["Message"] = "Room Add Successfully";
                    ans = dal.MST_Room_Add(model);
                }
            }
            
            if (ans)
            {
                TempData["Bool"] = true;
                return RedirectToAction("RoomView");
            }
            else
            {
                TempData["Bool"] = false;
                return RedirectToAction("RoomAddEdit");
            }
        }
        #endregion
        #region MST_Room_Search
        public IActionResult RoomSearch(string TypeName, string Status, int child , int adult)
        {
            Room_DALBase dal = new Room_DALBase();
            return View("RoomView", dal.MST_Room_Search(TypeName,Status,child,adult));
        }
        #endregion

        
    }
}
