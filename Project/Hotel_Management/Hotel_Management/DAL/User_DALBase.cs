using Hotel_Management.Areas.Hotel.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management.Areas.User.Models;
using System.Reflection;
using System.Collections.Generic;

namespace Hotel_Management.DAL
{
    public class User_DALBase : DAL_Helper
    {
        #region MST_UserCheckLogin
        /*public bool CheckLogin(UserLoginModel userLoginModel)
        {
			SqlDatabase db = new SqlDatabase(ConnStr);
			DbCommand cmd = db.GetStoredProcCommand("PR_SEC_User_SignIn");
			db.AddInParameter(cmd, "@Role", SqlDbType.VarChar, userLoginModel.UserName);
			db.AddInParameter(cmd, "@Role", SqlDbType.VarChar, userLoginModel.Password);
			using (IDataReader reader = db.ExecuteReader(cmd))
			{
				while (reader.Read())
				{
					HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
					HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
					HttpContext.Session.SetString("UserNumber", dr["UserNumber"].ToString());
					HttpContext.Session.SetString("Email", dr["Email"].ToString());
					HttpContext.Session.SetString("Password", dr["Password"].ToString());
					HttpContext.Session.SetString("IsAdmin", Convert.ToBoolean(dr["IsAdmin"]).ToString());
				}
			}
			return list;
		}*/
        #endregion
        #region MST_User_SignUp
        public bool MST_User_SignUp(SEC_UserModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_SEC_User_SignUp");
                db.AddInParameter(cmd, "@UserName", SqlDbType.VarChar, model.UserName);
                db.AddInParameter(cmd, "@UserNumber", SqlDbType.VarChar, model.UserNumber);
                db.AddInParameter(cmd, "@Password", SqlDbType.VarChar, model.Password);
                db.AddInParameter(cmd, "@Email", SqlDbType.VarChar, model.Email);
                int noOfRows = db.ExecuteNonQuery(cmd);
                if (noOfRows > 0) { return true; }
                else { return false; }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region MST_User_SelectAll
        public List<SEC_UserModel> MST_User_SelectAll()
        {
            List<SEC_UserModel> list = new List<SEC_UserModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_SEC_User_SelectAll");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    SEC_UserModel model = new SEC_UserModel();
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.UserName = reader["UserName"].ToString();
                    model.UserNumber = reader["UserNumber"].ToString();
                    model.Email = reader["Email"].ToString();
                    model.Password = reader["Password"].ToString();
                    model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    model.IsAdmin = Convert.ToBoolean(reader!["IsAdmin"]);
                    model.IsManager = Convert.ToBoolean(reader!["IsManager"]);
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
        #region MST_User_DeleteByUserID
        public bool MST_User_DeleteByUserID(int UserID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_SEC_User_DeleteByUserID");
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, UserID);
                int noOfRows = db.ExecuteNonQuery(cmd);
                if (noOfRows > 0) { return true; }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
