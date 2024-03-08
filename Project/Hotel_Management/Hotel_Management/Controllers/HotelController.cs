using Hotel_Management.Areas.Booking.Models;
using Hotel_Management.Areas.Room.Models;
using Hotel_Management.Areas.Staff.Models;
using Hotel_Management.DAL;
using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult About()
        {
            DashboardCount_DALBase dal = new DashboardCount_DALBase();
            Staff_DALBase staff_DALBase = new Staff_DALBase();
            BookingModel booking = new BookingModel();
            var count_dal = dal.MST_DashboardCount_SelectAll();
            var staff_dal = staff_DALBase.MST_Staff_SelectAll();
            var vModel = new Tuple<BookingModel, List<DashboardCountModel>, List<LOC_StaffModel>>(booking, count_dal, staff_dal);
            return View(vModel);
        }
        public IActionResult Servise()
        {
            BookingModel booking = new BookingModel();
            return View(booking);
        }
    }
}
