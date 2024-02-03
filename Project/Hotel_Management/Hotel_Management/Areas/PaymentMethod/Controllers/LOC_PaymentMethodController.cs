using Hotel_Management.Areas.PaymentMethod.Models;
using Hotel_Management.Areas.Role.Models;
using Hotel_Management.BAL;
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.PaymentMethod.Controllers
{
    [Area("PaymentMethod")]
    public class LOC_PaymentMethodController : Controller
    {
        #region MST_PaymentMethod_SelectAll
        public IActionResult PaymentMethodView()
        {
            PaymentMethod_DALBase dal = new PaymentMethod_DALBase();
            return View(dal.MST_PaymentMethod_SelectAll());
        }
        #endregion
        #region MST_PaymentMethod_DeleteByPaymentMethodID
        public IActionResult DeleteByPaymentMethodID(int PaymentMethodID)
        {
            try
            {
                PaymentMethod_DALBase dal = new PaymentMethod_DALBase();
                bool deleted = dal.MST_PaymentMethod_DeleteByPaymentMethodID(PaymentMethodID);
            }
            catch { }
            return RedirectToAction("PaymentMethodView");
        }
        #endregion
        #region MST_PaymentMethod_AddEdit
        public IActionResult PaymentMethodAddEdit(int PaymentMethodID)
        {
            if (PaymentMethodID == null)
            {
                return View();
            }
            else
            {
                PaymentMethod_DALBase dal = new PaymentMethod_DALBase();
                LOC_PaymentMethodModel model = dal.MST_PaymentMethod_SelectByPaymentMethodID(PaymentMethodID);
                return View(model);
            }

        }
        #endregion
        #region SaveForAddEdit
        public IActionResult SaveForAddEdit(LOC_PaymentMethodModel model)
        {
            bool ans = false;
            if (ModelState.IsValid)
            {
                PaymentMethod_DALBase dal = new PaymentMethod_DALBase();
                if (model.PaymentMethodID != null)
                {
                    ans = dal.MST_PaymentMethod_Update(model);
                }
                else
                {
                    ans = dal.MST_PaymentMethod_Add(model);
                }
            }
            if (ans)
            {
                return RedirectToAction("PaymentMethodView");
            }
            else
            {
                return RedirectToAction("PaymentMethodView");
            }
        }
        #endregion
        #region MST_Role_Search
        public IActionResult PaymentMethodSearch(string Method)
        {
            PaymentMethod_DALBase dal = new PaymentMethod_DALBase();
            return View("PaymentMethodView", dal.MST_PaymentMethod_Search(Method));
        }
        #endregion
    }
}
