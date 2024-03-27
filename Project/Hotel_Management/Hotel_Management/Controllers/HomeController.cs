using Hotel_Management.Areas.Booking.Models;
using Hotel_Management.Areas.Room.Models;
using Hotel_Management.Areas.Staff.Models;
using Hotel_Management.BAL;
using Hotel_Management.DAL;
using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;

namespace Hotel_Management.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region Method 01 :- Index Page
        public IActionResult Index()
        {
            DashboardCount_DALBase dal = new DashboardCount_DALBase();
            Staff_DALBase staff_DALBase = new Staff_DALBase();
            Room_DALBase room_DALBase = new Room_DALBase();
            BookingModel booking = new BookingModel();
            var count_dal = dal.MST_DashboardCount_SelectAll();
            var staff_dal = staff_DALBase.MST_Staff_SelectAll();
            var room_dal = room_DALBase.MST_Room_SelectAll();
            var vModel = new Tuple<BookingModel, List<DashboardCountModel>,List<LOC_RoomModel>,List<LOC_StaffModel>>(booking, count_dal,room_dal,staff_dal);
            return View(vModel);
        }
        #endregion
        #region Method 02 :- Admin Pannel
        [CheckAccessAdmin]
        public IActionResult AdminPannel()
        {
            String connectionStr = this._configuration.GetConnectionString("myConnectionString");
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connectionStr);
            conn.Open();
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Dashboord_Count";
            SqlDataReader objDataReader = objCmd.ExecuteReader();
            dt.Load(objDataReader);
            conn.Close();
            return View(dt);
        }
        #endregion
        #region Method 03 :- Error Page
        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]*/
        public IActionResult Error()
        {
            /*return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });*/
            return View();
        }
        #endregion
    }
}