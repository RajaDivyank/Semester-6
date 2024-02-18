using Hotel_Management.BAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class LOC_UserSideStaffController : Controller
    {
        #region User_Site_selectAll
        public IActionResult UserSideStaffView()
        {
            Staff_BALBase bal = new Staff_BALBase();
            return View(bal.MST_Staff_SelectAll());
        }
        #endregion
    }
}
