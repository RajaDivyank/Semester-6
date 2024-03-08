using Hotel_Management.Areas.Booking.Models;
using Hotel_Management.Areas.Staff.Models;
using Hotel_Management.BAL;
using Hotel_Management.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class LOC_UserSideStaffController : Controller
    {
        #region User_Site_selectAll
        public IActionResult UserSideStaffView()
        {
            Staff_DALBase dal = new Staff_DALBase();
            BookingModel booking = new BookingModel();
            var stafflist = dal.MST_Staff_SelectAll();
            var vModel = new Tuple<BookingModel,List<LOC_StaffModel>>(booking, stafflist);
            return View(vModel);
        }
        #endregion
    }
}
