using Hotel_Management.Areas.Roomtype.Models;
using Hotel_Management.BAL;
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.Roomtype.Controllers
{
    [Area("Roomtype")]
    public class LOC_RoomTypeController : Controller
    {
        #region MST_RoomType_SelectAll
        public IActionResult RoomTypeView()
        {
            RoomType_DALBase dal = new RoomType_DALBase();
            return View(dal.MST_RoomType_SelectAll());
        }
        #endregion
        #region MST_RoomType_DeleteByRoomTypeID
        public IActionResult DeleteByRoomTypeID(int RoomTypeID)
        {
            try
            {
                RoomType_DALBase dal = new RoomType_DALBase();
                bool deleted = dal.MST_RoomType_DeleteByRoomTypeID(RoomTypeID);
            }
            catch { }
            return RedirectToAction("RoomTypeView");
        }
        #endregion
        #region MST_RoomType_SelectByRoomTypeID
        public IActionResult RoomTypeAddEdit(int RoomTypeID)
        {
            if (RoomTypeID == null)
            {
                return View();
            }
            else
            {
                RoomType_DALBase dal = new RoomType_DALBase();
                LOC_RoomTypeModel model = dal.MST_RoomType_SelectByRoomTypeID(RoomTypeID);
                return View(model);
            }

        }
        #endregion
        #region SaveForAddEdit
        public IActionResult SaveForAddEdit(LOC_RoomTypeModel model)
        {
            bool ans = false;
            if (ModelState.IsValid)
            {
                RoomType_DALBase dal = new RoomType_DALBase();
                if (model.RoomTypeID != null)
                {
                    ans = dal.MST_RoomType_Update(model);
                }
                else
                {
                    ans = dal.MST_RoomType_Add(model);
                }
            }
            if (ans)
            {
                return RedirectToAction("RoomTypeView");
            }
            else
            {
                return RedirectToAction("RoomTypeView");
            }
        }
        #endregion
        #region MST_RoomType_Search
        public IActionResult RoomTypeSearch(string TypeName, decimal PricePerDay)
        {
            RoomType_DALBase dal = new RoomType_DALBase();
            return View("RoomTypeView", dal.MST_RoomType_Search(TypeName,PricePerDay));
        }
        #endregion
    }
}
