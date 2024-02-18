using Hotel_Management.DAL;
using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Hotel_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            DashboardCount_DALBase dal = new DashboardCount_DALBase();
            return View(dal.MST_DashboardCount_SelectAll());
        }
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
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}