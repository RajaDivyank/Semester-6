using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Hotel_Management.Areas.Hotel.Models;

namespace Hotel_Management.Areas.Hotel.Controllers
{
    [Area("Hotel")]
    public class LOC_HotelController : Controller
    {
        private readonly IConfiguration _configuration;
        public LOC_HotelController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult HotelView()
        {
            String connectionStr = this._configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(connectionStr);
            conn.Open();
            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "PR_LOC_Hotel_SelectAll";
            DataTable dt = new DataTable();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return View(dt);
        }
        public IActionResult DeleteHotel(int HotelID)
        {
            try
            {
                String connectionStr = this._configuration.GetConnectionString("myConnectionString");
                SqlConnection conn = new SqlConnection(connectionStr);
                conn.Open();
                SqlCommand objCmd = conn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_LOC_Hotel_DeleteByHotelID";
                objCmd.Parameters.AddWithValue("@HotelID", HotelID);
                int rowsAffected = objCmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    return RedirectToAction("HotelView");
                }
                else
                { 
                    return RedirectToAction("HotelView");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("HotelView");
            }
        }
        public IActionResult SelectByHotelID(int? HotelID)
        {
            if (HotelID == null)
            {
                return View();

            }
            else
            {
                string connectionString = this._configuration.GetConnectionString("myConnectionString");
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_LOC_Hotel_SelectByHotelID";
                cmd.Parameters.AddWithValue("@HotelID", HotelID);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                LOC_HotelModel model = new LOC_HotelModel();
                model.HotelID = HotelID;
                model.HotelName = (string)dataTable.Rows[0]["HotelName"];
                model.HotelAddress = (string)dataTable.Rows[0]["HotelAddress"];
                model.HotelEmail = (string)dataTable.Rows[0]["HotelEmail"];
                model.Rating = (decimal)dataTable.Rows[0].["Rating"];
                model.OwnerName = (string)dataTable.Rows[0]["OwnerName"];
                model.HotelPhoneNumber = (string)dataTable.Rows[0]["HotelPhoneNumber"];
                model.Created = (DateTime)dataTable.Rows[0]["Created"];
                model.Modified = (DateTime)dataTable.Rows[0]["Modified"];
                return View(model);
            }

        }
    }
}
