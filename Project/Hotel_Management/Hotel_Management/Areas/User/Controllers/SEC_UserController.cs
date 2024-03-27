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
		#region Method 01 :-  Display User List 
		public IActionResult UserView()
		{
            User_DALBase dal = new User_DALBase();
            return View(dal.MST_User_SelectAll());
        }
		#endregion
		#region Method 02 :-  Login Page
		public IActionResult Login()
        {
            return View();
        }
		#endregion
		#region Method 03 :-  Check UserName and Password
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
		#endregion
		#region Method 04 :-  Logout 
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home", new { area = "" });
		}
		#endregion
		#region Method 05 :- User Registration
		public IActionResult SignUp(int UserID)
        {
            User_DALBase dal = new User_DALBase();
			SEC_UserModel model = dal.MST_User_SelectByUserID(UserID);
            return View(model);
        }
		#endregion
		#region Method 06 :- Save Registration
		public IActionResult SignUpSave(SEC_UserModel model)
		{
            bool ans = false;
             User_DALBase dal = new User_DALBase();
            if (ModelState.IsValid)
            {
                if (model.UserID == null)
                {
                    ans = dal.MST_User_SignUp(model);
                }
				else
				{
					ans = dal.MST_User_UpdateDetail(model);
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
		#endregion
		#region Method 07 :- Detele User By UserID
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
        #endregion
        #region Method 08 :- User Update Detail
        public IActionResult EditUser(int UserID)
		{
			User_DALBase user = new User_DALBase();
			SEC_UserModel model = user.MST_User_SelectByUserID(UserID);
			return View(model);
		}
		#endregion
		#region Method 09 :- Save User Update
		public IActionResult SaveUpdate(SEC_UserModel model)
		{
            bool ans = false;
			User_DALBase dALBase = new User_DALBase();
			ans = dALBase.MST_User_Update(model);
			if (ans)
			{
				return RedirectToAction("UserView");
			}
			else
			{
				return RedirectToAction("EditUser");
			}
		}
		#endregion
	}
}
