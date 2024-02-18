using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management.Areas.Roomstatus.Models;
using Hotel_Management.BAL;

namespace Hotel_Management.DAL
{
    public class RoomStatus_DALBase : DAL_Helper
    {
        #region MST_RoomStatus_SelectAll
        public List<LOC_RoomStatusModel> MST_RoomStatus_SelectAll()
        {
            List<LOC_RoomStatusModel> list = new List<LOC_RoomStatusModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_RoomStatus_SelectAll");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_RoomStatusModel model = new LOC_RoomStatusModel();
                    model.StatusID = Convert.ToInt32(reader["StatusID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.Status = reader["Status"].ToString();
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
        #region MST_RoomStatus_SelectByStatusID
        public LOC_RoomStatusModel MST_RoomStatus_SelectByStatusID(int StatusID)
        {
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_RoomStatus_SelectByStatusID");
            db.AddInParameter(cmd, "@StatusID", SqlDbType.Int, StatusID);
            LOC_RoomStatusModel model = new LOC_RoomStatusModel();
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    model.StatusID = Convert.ToInt32(reader["StatusID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.Status = reader["Status"].ToString();
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                }
            }
            return model;
        }
        #endregion
        #region MST_RoomStatus_DeleteByStatusID
        public bool MST_RoomStatus_DeleteByStatusID(int StatusID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_RoomStatus_DeleteByStatusID");
                db.AddInParameter(cmd, "@StatusID", SqlDbType.Int, StatusID);
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
        #region MST_RoomStatus_Add
        public bool MST_RoomStatus_Add(LOC_RoomStatusModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_RoomStatus_InsertRecord");
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, CommonVariables.UserID());
                db.AddInParameter(cmd, "@Status", SqlDbType.VarChar, model.Status);
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
        #region MST_RoomStatus_Update
        public bool MST_RoomStatus_Update(LOC_RoomStatusModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_RoomStatus_UpdateRecord");
                db.AddInParameter(cmd, "@StatusID", SqlDbType.Int, model.StatusID);
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, CommonVariables.UserID());
                db.AddInParameter(cmd, "@Status", SqlDbType.VarChar, model.Status);
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
        #region MST_RoomStatus_Search
        public List<LOC_RoomStatusModel> MST_RoomStatus_Search(string Status)
        {
            List<LOC_RoomStatusModel> list = new List<LOC_RoomStatusModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_RoomStatus_Filter");
            db.AddInParameter(cmd, "@Status", SqlDbType.VarChar, Status);
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_RoomStatusModel model = new LOC_RoomStatusModel();
                    model.StatusID = Convert.ToInt32(reader["StatusID"]);
                    model.Status = reader["Status"].ToString();
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
