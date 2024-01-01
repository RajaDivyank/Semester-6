using Hotel_Management.Areas.Role.Models;
using Hotel_Management.BAL;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Hotel_Management.Areas.Role.Controllers
{
    [Area("Role")]
    public class LOC_RoleController : Controller
    {
        #region MST_Role_SelectAll
        public IActionResult RoleView()
        {
            Role_BALBase bal = new Role_BALBase();
            return View(bal.MST_Role_SelectAll());
        }
        #endregion
        #region MST_Role_DeleteByRoleID
        public IActionResult DeleteByRoleID(int RoleID)
        {
            try
            {
                Role_BALBase bal = new Role_BALBase();
                bool deleted = bal.MST_Role_DeleteByRoleID(RoleID);
            }
            catch { }
            return RedirectToAction("RoleView");
        }
        #endregion
        #region MST_Role_AddEdit
        public IActionResult RoleAddEdit(int RoleID)
        {
            if (RoleID == null)
            {
                return View();
            }
            else
            {
                Role_BALBase bal = new Role_BALBase();
                LOC_RoleModel model = bal.MST_Role_SelectByRoleID(RoleID);
                return View(model);
            }

        }
        #endregion
        #region SaveForAddEdit
        public IActionResult SaveForAddEdit(LOC_RoleModel model)
        {
            bool ans = false;
            if (ModelState.IsValid)
            {
                Role_BALBase bal = new Role_BALBase();
                if (model.RoleID != null)
                {
                    ans = bal.MST_Role_Update(model);
                }
                else
                {
                    ans = bal.MST_Role_Add(model);
                }
            }
            if (ans)
            {
                return RedirectToAction("RoleView");
            }
            else
            {
                return RedirectToAction("RoleView");
            }
        }
        #endregion
        #region MST_Role_Search
        public IActionResult RoleSearch(string Role)
        {
            Role_BALBase bal = new Role_BALBase();
            return View("RoleView", bal.MST_Role_Search(Role));
        }
        #endregion
    }
}
