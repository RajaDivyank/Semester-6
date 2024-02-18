 using Hotel_Management.Areas.Roomstatus.Models;
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.Roomstatus.Controllers
{
    [Area("Roomstatus")]
    public class RoomStatusController : Controller
    {
        #region MST_Status_SelectAll
        public IActionResult StatusView()
        {
            RoomStatus_DALBase dal = new RoomStatus_DALBase();
            return View(dal.MST_RoomStatus_SelectAll());
        }
        #endregion
        #region MST_Status_DeleteByStatusID
        public IActionResult DeleteByStatusID(int StatusID)
        {
            try
            {
                TempData["Message"] = "Status Delete Successfully";
                RoomStatus_DALBase dal = new RoomStatus_DALBase();
                bool deleted = dal.MST_RoomStatus_DeleteByStatusID(StatusID);
            }
            catch { }
            return RedirectToAction("StatusView");
        }
        #endregion
        #region MST_Status_AddEdit
        public IActionResult StatusAddEdit(int StatusID)
        {
            if (StatusID == null)
            {
                return View();
            }
            else
            {
                RoomStatus_DALBase bal = new RoomStatus_DALBase();
                LOC_RoomStatusModel model = bal.MST_RoomStatus_SelectByStatusID(StatusID);
                TempData["Message"] = "Status Not Edit Successfully";
                return View(model);
            }

        }
        #endregion
        #region SaveForAddEdit
        public IActionResult SaveForAddEdit(LOC_RoomStatusModel model)
        {
            bool ans = false;
            if (ModelState.IsValid)
            {
                RoomStatus_DALBase dal = new RoomStatus_DALBase();
                if (model.StatusID != null)
                {
                    TempData["Message"] = "Status Edit Successfully";
                    ans = dal.MST_RoomStatus_Update(model);
                }
                else
                {
                    TempData["Message"] = "Status Add Successfully";
                    ans = dal.MST_RoomStatus_Add(model);
                }
            }
            if (ans)
            {
                TempData["Bool"] = true;
                return RedirectToAction("StatusView");
            }
            else
            {
                TempData["Bool"] = false;
                return RedirectToAction("StatusAddEdit");
            }
        }
        #endregion
        #region MST_Status_Search
        public IActionResult StatusSearch(string Status)
        {
            RoomStatus_DALBase bal = new RoomStatus_DALBase();
            return View("StatusView", bal.MST_RoomStatus_Search(Status));
        }
        #endregion
    }
}
