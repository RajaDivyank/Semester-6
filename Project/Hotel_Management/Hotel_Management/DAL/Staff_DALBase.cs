using Hotel_Management.Areas.User.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management.Areas.Staff.Models;

namespace Hotel_Management.DAL
{
    public class Staff_DALBase : DAL_Helper
    {
        #region MST_Staff_SelectAll
        public List<LOC_StaffModel> MST_Staff_SelectAll()
        {
            List<LOC_StaffModel> list = new List<LOC_StaffModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Staff_SelectAll");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_StaffModel model = new LOC_StaffModel();
                    model.StaffID = Convert.ToInt32(reader["StaffID"]);
                    model.RoleID = Convert.ToInt32(reader["RoleID"]);
                    model.FirstName = reader["FirstName"].ToString();
                    model.LastName = reader["LastName"].ToString();
                    model.Role = reader["Role"].ToString();
                    model.StaffImage = reader["StaffImage"].ToString();
                    model.Salary = Convert.ToDecimal(reader["Salary"].ToString());
                    model.StaffNumber = reader["StaffNumber"].ToString();
                    model.StaffEmail = reader["StaffEmail"].ToString();
                    model.IDProof = reader["IDProof"].ToString();
                    model.IDProofPhotoPath = reader["IDProofPhotoPath"].ToString();
                    model.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    model.DateOfJoining = Convert.ToDateTime(reader["DateOfJoining"]);
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
        #region MST_Staff_SelectByStaffID
        public LOC_StaffModel MST_Staff_SelectByStaffID(int StaffID)
        {
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Staff_SelectByStaffID");
            db.AddInParameter(cmd, "@StaffID", SqlDbType.Int, StaffID);
            LOC_StaffModel model = new LOC_StaffModel();
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    model.StaffID = Convert.ToInt32(reader["StaffID"]);
                    model.RoleID = Convert.ToInt32(reader["RoleID"]);
                    model.FirstName = reader["FirstName"].ToString();
                    model.LastName = reader["LastName"].ToString();
                    model.Salary = Convert.ToDecimal(reader["Salary"].ToString());
                    model.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    model.StaffNumber = reader["StaffNumber"].ToString();
                    model.StaffEmail = reader["StaffEmail"].ToString();
                    model.StaffImage = reader["StaffImage"].ToString();
                    model.DateOfJoining = Convert.ToDateTime(reader["DateOfJoining"]);
                    model.IDProof = reader["IDProof"].ToString();
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                }
            }
            return model;
        }
        #endregion
        #region MST_Staff_DeleteByStaffID
        public bool MST_Staff_DeleteByStaffID(int StaffID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Staff_DeleteByStaffID");
                db.AddInParameter(cmd, "@StaffID", SqlDbType.Int, StaffID);
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
        #region MST_Staff_Add
        public bool MST_Staff_Add(LOC_StaffModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Staff_InsertRecord");
                db.AddInParameter(cmd, "@RoleID", SqlDbType.Int, model.RoleID);
                db.AddInParameter(cmd, "@FirstName", SqlDbType.VarChar, model.FirstName);
                db.AddInParameter(cmd, "@LastName", SqlDbType.VarChar, model.LastName);
                db.AddInParameter(cmd, "@Salary", SqlDbType.Decimal, model.Salary);
                db.AddInParameter(cmd, "@StaffImage", SqlDbType.VarChar, model.StaffImage);
                db.AddInParameter(cmd, "@StaffNumber", SqlDbType.VarChar, model.StaffNumber);
                db.AddInParameter(cmd, "@StaffEmail", SqlDbType.VarChar, model.StaffEmail);
                db.AddInParameter(cmd, "@DateOfBirth", SqlDbType.Date, model.DateOfBirth);
                db.AddInParameter(cmd, "@DateOfJoining", SqlDbType.Date, model.DateOfJoining);
                db.AddInParameter(cmd, "@IDProofPhotoPath", SqlDbType.VarChar, model.IDProofPhotoPath);
                db.AddInParameter(cmd, "@IDProof", SqlDbType.VarChar, model.IDProof);
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
        #region MST_Staff_Update
        public bool MST_Staff_Update(LOC_StaffModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Staff_UpdateRecord");
                db.AddInParameter(cmd, "@StaffID", SqlDbType.Int, model.StaffID);
                db.AddInParameter(cmd, "@RoleID", SqlDbType.Int, model.RoleID);
                db.AddInParameter(cmd, "@FirstName", SqlDbType.VarChar, model.FirstName);
                db.AddInParameter(cmd, "@LastName", SqlDbType.VarChar, model.LastName);
                db.AddInParameter(cmd, "@Salary", SqlDbType.Decimal, model.Salary);
                db.AddInParameter(cmd, "@DateOfBirth", SqlDbType.Date, model.DateOfBirth);
                db.AddInParameter(cmd, "@StaffNumber", SqlDbType.VarChar, model.StaffNumber);
                db.AddInParameter(cmd, "@StaffEmail", SqlDbType.VarChar, model.StaffEmail);
                db.AddInParameter(cmd, "@DateOfJoining", SqlDbType.Date, model.DateOfJoining);
                db.AddInParameter(cmd, "@IDProofPhotoPath", SqlDbType.VarChar, model.IDProofPhotoPath);
                db.AddInParameter(cmd, "@IDProof", SqlDbType.VarChar, model.IDProof);
                db.AddInParameter(cmd, "@StaffImage", SqlDbType.VarChar, model.StaffImage);
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
