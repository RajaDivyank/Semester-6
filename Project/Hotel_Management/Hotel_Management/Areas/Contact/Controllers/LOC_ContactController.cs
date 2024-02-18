using Hotel_Management.Areas.Contact.Models;
using Hotel_Management.Areas.Roomtype.Models;
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.Contact.Controllers
{
    [Area("Contact")]
    public class LOC_ContactController : Controller
    {
        #region MST_Contact_SelectAll
        public IActionResult ContactView()
        {
            Contact_DALBase dal = new Contact_DALBase();
            return View(dal.MST_Contact_SelectAll());
        }
        #endregion
        #region MST_Contact_DeleteByContactID
        public IActionResult DeleteByContactID(int ContactID)
        {
            try
            {
                Contact_DALBase dal = new Contact_DALBase();
                bool deleted = dal.MST_Contact_DeleteByContactID(ContactID);
            }
            catch { }
            return RedirectToAction("ContactView");
        }
        #endregion
        #region MST_Contact_SelectByContactID
        public IActionResult ContactAddEdit(int ContactID)
        {
            if (ContactID == null)
            {
                return View();
            }
            else
            {
                Contact_DALBase dal = new Contact_DALBase();
                LOC_ContactModel model = dal.MST_Contact_SelectByContactID(ContactID);
                return View(model);
            }

        }
        #endregion
        #region SaveForAddEdit
        public IActionResult SaveForAddEdit(LOC_ContactModel model)
        {
            bool ans = false;
            if (ModelState.IsValid)
            {
                Contact_DALBase dal = new Contact_DALBase();
                if (model.ContactID != null)
                {
                    ans = dal.MST_Contact_Update(model);
                }
                else
                {
                    ans = dal.MST_Contact_Add(model);
                }
            }
            if (ans)
            {
                return RedirectToAction("ContactView");
            }
            else
            {
                return RedirectToAction("ContactAddEdit");
            }
        }
        #endregion
        #region MST_Contact_Search
        public IActionResult ContactSearch(string? Name, string? Email)
        {
            Contact_DALBase dal = new Contact_DALBase();
            return View("ContactView", dal.MST_Contact_Search(Name, Email));
        }
        #endregion
    }
}
