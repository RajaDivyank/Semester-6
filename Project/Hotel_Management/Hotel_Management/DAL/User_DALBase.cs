using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management.Areas.User.Models;
using Hotel_Management.BAL;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.DAL
{
    public class User_DALBase : DAL_Helper
    {
        #region Method 1 :- User Registration
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
        #region Method 2 :- Get All User
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
        #region Method 3 :- Get User By UserID
        public SEC_UserModel MST_User_SelectByUserID(int UserID)
        {
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_SEC_User_SelectByUserID");
            db.AddInParameter(cmd, "@UserID", SqlDbType.Int, UserID);
            SEC_UserModel model = new SEC_UserModel();
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.UserName = reader["UserName"].ToString();
                    model.UserNumber = reader["UserNumber"].ToString();
                    model.Email = reader["Email"].ToString();
                    model.Password = reader["Password"].ToString();
                    model.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                    model.IsManager = Convert.ToBoolean(reader["IsManager"]);
                    model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                }
            }
            return model;
        }
        #endregion
        #region Method 4 :- Delete By UserID
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
        #region Method 4 :- Update Admin and Manager
        public bool MST_User_Update(SEC_UserModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_SEC_User_UpdateByUserID");
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, model.UserID);
                db.AddInParameter(cmd, "@IsAdmin", SqlDbType.Bit, model.IsAdmin);
                db.AddInParameter(cmd, "@IsManager", SqlDbType.Bit, model.IsManager);
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
        #region Method 5 :- Update User Detail
        public bool MST_User_UpdateDetail(SEC_UserModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_User_UpdateByUserID");
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, model.UserID);
                db.AddInParameter(cmd, "@UserName", SqlDbType.VarChar, model.UserName);
                db.AddInParameter(cmd, "@Password", SqlDbType.VarChar, model.Password);
                db.AddInParameter(cmd, "@Email", SqlDbType.VarChar, model.Email);
                db.AddInParameter(cmd, "@UserNumber", SqlDbType.VarChar, model.UserNumber);
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
