using Hotel_Management.Areas.Role.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Hotel_Management.DAL
{
    public class Role_DALBase : DAL_Helper
    {
        #region MST_Role_SelectAll
        public List<LOC_RoleModel> MST_Role_SelectAll()
        {
            List<LOC_RoleModel> list = new List<LOC_RoleModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Role_SelectAll");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_RoleModel model = new LOC_RoleModel();
                    model.RoleID = Convert.ToInt32(reader["RoleID"]);
                    model.Role = reader["Role"].ToString();
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
        #region MST_Role_SelectByRoleID
        public LOC_RoleModel MST_Role_SelectByRoleID(int RoleID)
        {
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Role_SelectByRoleID");
            db.AddInParameter(cmd, "@RoleID", SqlDbType.Int, RoleID);
            LOC_RoleModel model = new LOC_RoleModel();
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    model.RoleID = Convert.ToInt32(reader["RoleID"]);
                    model.Role = reader["Role"].ToString();
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                }
            }
            return model;
        }
        #endregion
        #region MST_Role_DeleteByRoleID
        public bool MST_Role_DeleteByRoleID(int RoleID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Role_DeleteByRoleID");
                db.AddInParameter(cmd, "@RoleID", SqlDbType.Int, RoleID);
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
        #region MST_Role_Add
        public bool MST_Role_Add(LOC_RoleModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Role_InsertRecord");
                db.AddInParameter(cmd, "@Role", SqlDbType.VarChar, model.Role);
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
        #region MST_Role_Update
        public bool MST_Role_Update(LOC_RoleModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Role_UpdateRecord");
                db.AddInParameter(cmd, "@RoleID", SqlDbType.Int, model.RoleID);
                db.AddInParameter(cmd, "@Role", SqlDbType.VarChar, model.Role);
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
        #region MST_Role_Search
        public List<LOC_RoleModel> MST_Role_Search(string Role)
        {
            List<LOC_RoleModel> list = new List<LOC_RoleModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Role_Filter");
            db.AddInParameter(cmd, "@Role", SqlDbType.VarChar, Role);
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_RoleModel model = new LOC_RoleModel();
                    model.RoleID = Convert.ToInt32(reader["RoleID"]);
                    model.Role = reader["Role"].ToString();
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
    }
}
