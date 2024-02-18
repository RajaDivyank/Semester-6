using Hotel_Management.Areas.Contact.Models;
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.Contact.Controllers
{
    [Area("Contact")]
    public class LOC_UserSideContactController : Controller
    {
        public IActionResult UserSideContactAdd()
        {
            return View();
        }
        public IActionResult SaveForAddEdit(LOC_ContactModel model)
        {
            bool ans = false;
            if (ModelState.IsValid)
            {
                Contact_DALBase dal = new Contact_DALBase();
                if (model.ContactID == null)
                {
                    ans = dal.MST_Contact_Add(model);
                }
            }
            if (ans)
            {
                TempData["Bool"] = true;
                TempData["Message"] = "Contact Added Successfully";
                return RedirectToAction("UserSideContactAdd");
            }
            else
            {
                TempData["Bool"] = false;
                TempData["Message"] = "Contact Not Added";
                return RedirectToAction("UserSideContactAdd");
            }
        }
    }
}
