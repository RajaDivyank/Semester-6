using Hotel_Management.Areas.Staff.Models;
using Hotel_Management.Areas.User.Models;
using Hotel_Management.BAL;
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class LOC_StaffController : Controller
    {
        #region MST_Staff_SelectAll
        public IActionResult StaffView()
        {
            Staff_BALBase bal = new Staff_BALBase();
            return View(bal.MST_Staff_SelectAll());
        }
        #endregion
        #region MST_Staff_SelectByStaffID
        public IActionResult StaffDetail(int StaffID)
        {
            Staff_BALBase bal = new Staff_BALBase();
            LOC_StaffModel model = bal.MST_Staff_SelectByStaffID(StaffID);
            return View(model);

        }
        #endregion
        #region MST_Staff_DeleteByStaffID
        public IActionResult DeleteByStaffID(int StaffID)
        {
            try
            {
                Staff_BALBase bal = new Staff_BALBase();
                bool deleted = bal.MST_Staff_DeleteByStaffID(StaffID);
            }
            catch { }
            return RedirectToAction("StaffView");
        }
        #endregion
        #region MST_Staff_AddEdit
        public IActionResult StaffAddEdit(int StaffID)
        {
            if (StaffID == null)
            {
                return View();
            }
            else
            {
                Staff_BALBase bal = new Staff_BALBase();
                LOC_StaffModel model = bal.MST_Staff_SelectByStaffID(StaffID);
                return View(model);
            }
        }
        #endregion
        #region SaveForAddEdit
        public IActionResult SaveForAddEdit(LOC_StaffModel model)
        {
            bool ans = false;
            if (ModelState.IsValid)
            {
                Staff_BALBase bal = new Staff_BALBase();
                if (model.StaffID != null)
                {
                    ans = bal.MST_Staff_Update(model);
                }
                else
                {
                    ans = bal.MST_Staff_Add(model);
                }
            }
            if (ans)
            {
                return RedirectToAction("StaffView");
            }
            else
            {
                return RedirectToAction("StaffView");
            }
        }
        #endregion
    }
}
