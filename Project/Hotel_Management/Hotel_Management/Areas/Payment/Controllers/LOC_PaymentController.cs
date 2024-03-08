using Hotel_Management.Areas.Booking.Models;
using Hotel_Management.Areas.Payment.Models;
using Hotel_Management.Areas.PaymentMethod.Models;
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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
        #region Add Payment By BookingID
        public IActionResult PaymentAddEdit(int BookingID)
        {

            Booking_DALBase booking_DALBase = new Booking_DALBase();
            PaymentMethod_DALBase paydal = new PaymentMethod_DALBase();
            LOC_PaymentModel paymentModel = new LOC_PaymentModel();
            LOC_BookingModel bookingModel = booking_DALBase.MST_Booking_SelectByBookingID(BookingID);
            paymentModel.paymentmethods = paydal.MST_PaymentMethod_SelectAll();
            paymentModel.BookingID = bookingModel.BookingID;
            paymentModel.RegistrationName = bookingModel.RegistrationName;
            paymentModel.MobileNumber = bookingModel.MobileNumber;
            paymentModel.AdultCapacity = bookingModel.AdultCapacity;
            paymentModel.ChildCapacity = bookingModel.ChildCapacity;
            paymentModel.PricePerDay = bookingModel.PricePerDay;
            paymentModel.TypeName = bookingModel.TypeName;
            paymentModel.TotalDays = bookingModel.TotalDays;
            paymentModel.CheckIn = bookingModel.CheckIn;
            paymentModel.CheckOut = bookingModel.CheckOut;
            paymentModel.SpecialRequest = bookingModel.SpecialRequest;
            var price = bookingModel.PricePerDay;
            var days = bookingModel.TotalDays;
            paymentModel.Amount = Convert.ToDecimal(price * days);
            return View(paymentModel);

            /*PaymentMethod_DALBase paydal = new PaymentMethod_DALBase();
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
            }*/

        }
        #endregion
        #region Edit Payment By PaymentID
        public IActionResult PaymentEdit(int PaymentID,int BookingID)
        {
            Booking_DALBase booking_DALBase = new Booking_DALBase();
            LOC_BookingModel bookingModel = booking_DALBase.MST_Booking_SelectByBookingID(BookingID);
            PaymentMethod_DALBase paydal = new PaymentMethod_DALBase();
            LOC_PaymentModel paymentModel = new LOC_PaymentModel();
            PaymentDAL_Base paymentDAL_Base = new PaymentDAL_Base();
            paymentModel = paymentDAL_Base.MST_Payment_SelectByPaymentID(PaymentID);
            paymentModel.paymentmethods = paydal.MST_PaymentMethod_SelectAll();
            paymentModel.BookingID = bookingModel.BookingID;
            paymentModel.RegistrationName = bookingModel.RegistrationName;
            paymentModel.MobileNumber = bookingModel.MobileNumber;
            paymentModel.AdultCapacity = bookingModel.AdultCapacity;
            paymentModel.ChildCapacity = bookingModel.ChildCapacity;
            paymentModel.PricePerDay = bookingModel.PricePerDay;
            paymentModel.TypeName = bookingModel.TypeName;
            paymentModel.TotalDays = bookingModel.TotalDays;
            paymentModel.CheckIn = bookingModel.CheckIn;
            paymentModel.CheckOut = bookingModel.CheckOut;
            paymentModel.SpecialRequest = bookingModel.SpecialRequest;
            var price = bookingModel.PricePerDay;
            var days = bookingModel.TotalDays;
            paymentModel.Amount = Convert.ToDecimal(price * days);
            return View("PaymentAddEdit", paymentModel);
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
