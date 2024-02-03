using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Hotel_Management.Areas.User.Models;
/*using Hotel_Management.BAL;*/
using System.Reflection;
using Hotel_Management.DAL;

namespace Hotel_Management.Areas.User.Controllers
{
    [Area("User")]
    public class SEC_UserController : Controller
    {
		private readonly IConfiguration _configuration;
		public SEC_UserController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public IActionResult UserView()
		{
            User_DALBase dal = new User_DALBase();
            return View(dal.MST_User_SelectAll());
        }
		public IActionResult Login()
        {
            return View();
        }
		public IActionResult Save(UserLoginModel userLoginModel)
		{
			string ErrorMsg = string.Empty;
			if (string.IsNullOrEmpty(userLoginModel.UserName))
			{
				ErrorMsg += "User Name is Required";
			}
			if (string.IsNullOrEmpty(userLoginModel.Password))
			{
				ErrorMsg += "<br/>Password is Required";
			}
			if (ModelState.IsValid)
			{
				SqlConnection conn = new SqlConnection(this._configuration.GetConnectionString("myConnectionString"));
				conn.Open();
				SqlCommand objCmd = conn.CreateCommand();
				objCmd.CommandType = CommandType.StoredProcedure;
				objCmd.CommandText = "PR_SEC_User_SignIn";
				objCmd.Parameters.AddWithValue("@EmailOrUserName", userLoginModel.UserName);
				objCmd.Parameters.AddWithValue("@Password", userLoginModel.Password);

				SqlDataReader objSDR = objCmd.ExecuteReader();
				DataTable dtLogin = new DataTable();
				if (!objSDR.HasRows)
				{
					TempData["ErrorMessage"] = "Invalid User Name or Password";
					return RedirectToAction("Login", "SEC_User", new {area="User"});
				}
				else
				{
					dtLogin.Load(objSDR);
					foreach (DataRow dr in dtLogin.Rows)
					{
						HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
						HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
						HttpContext.Session.SetString("UserNumber", dr["UserNumber"].ToString());
						HttpContext.Session.SetString("Email", dr["Email"].ToString());
						HttpContext.Session.SetString("Password", dr["Password"].ToString());
						HttpContext.Session.SetString("IsAdmin", Convert.ToBoolean(dr["IsAdmin"]).ToString());
						HttpContext.Session.SetString("IsManager", Convert.ToBoolean(dr["IsManager"]).ToString());

					}
					return RedirectToAction("Index", "Home", new { area = "" });
				}
			}
			else
			{
				TempData["ErrorMessage"] = ErrorMsg;
				return RedirectToAction("Login", "SEC_User", new { area = "User" });
			}
		}
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home", new { area = "" });
		}
        public IActionResult SignUp()
        {
            return View();
        }
		public IActionResult SignUpSave(SEC_UserModel model)
		{
            bool ans = false;
            if (ModelState.IsValid)
            {
                User_DALBase dal = new User_DALBase();
                if (model.UserID == null)
                {
                    ans = dal.MST_User_SignUp(model);
                }
            }
            if (ans)
            {
                return RedirectToAction("Index" , "Home" , new { area = ""});
            }
            else
            {
                return RedirectToAction("SignUp","SEC_User",new {area = "User"});
            }
        }
		public IActionResult DeleteByUserID(int UserID)
		{
            try
            {
                User_DALBase dal = new User_DALBase();
                bool deleted = dal.MST_User_DeleteByUserID(UserID);
            }
            catch { }
            return RedirectToAction("UserView");
        }
    }
}
