using Hotel_Management.Areas.Payment.Models;
using Hotel_Management.Areas.PaymentMethod.Models;
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.Payment.Controllers
{
    [Area("Payment")]
    public class LOC_PaymentController : Controller
    {
        #region MST_Payment_SelectAll
        public IActionResult PaymentView()
        {
            PaymentDAL_Base dal = new PaymentDAL_Base();
            return View(dal.MST_Payment_SelectAll());
        }
        #endregion
        #region MST_Payment_DeleteByPaymentID
        public IActionResult DeleteByPaymentID(int PaymentID)
        {
            try
            {
                PaymentDAL_Base dal = new PaymentDAL_Base();
                bool deleted = dal.MST_Payment_DeleteByPaymentID(PaymentID);
            }
            catch { }
            return RedirectToAction("PaymentView");
        }
        #endregion
        #region MST_Payment_AddEdit
        public IActionResult PaymentAddEdit(int PaymentID)
        {
            PaymentMethod_DALBase paydal = new PaymentMethod_DALBase();
            if (PaymentID == 0)
            {
                LOC_PaymentModel model = new LOC_PaymentModel();
                model.paymentmethods = paydal.MST_PaymentMethod_SelectAll();
                return View(model);
            }
            else
            {
                PaymentDAL_Base dal = new PaymentDAL_Base();
                LOC_PaymentModel model = dal.MST_Payment_SelectByPaymentID(PaymentID);
                model.paymentmethods = paydal.MST_PaymentMethod_SelectAll();
                return View(model);
            }

        }
        #endregion
        #region SaveForAddEdit
        public IActionResult SaveForAddEdit(LOC_PaymentModel model)
        {
            bool ans = false;
            if (ModelState.IsValid)
            {
                PaymentDAL_Base dal = new PaymentDAL_Base();
                if (model.PaymentID != null)
                {
                    ans = dal.MST_Payment_Update(model);
                }
                else
                {
                    ans = dal.MST_Payment_Add(model);
                }
            }
            if (ans)
            {
                return RedirectToAction("PaymentView");
            }
            else
            {
                return RedirectToAction("PaymentView");
            }
        }
        #endregion
    }
}
