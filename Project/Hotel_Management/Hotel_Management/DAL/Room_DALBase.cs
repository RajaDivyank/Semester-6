using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management.Areas.Room.Models;
using Hotel_Management.BAL;

namespace Hotel_Management.DAL
{
    public class Room_DALBase : DAL_Helper
    {
        #region MST_Room_SelectAll
        public List<LOC_RoomModel> MST_Room_SelectAll()
        {
            List<LOC_RoomModel> list = new List<LOC_RoomModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Room_SelectAll");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_RoomModel model = new LOC_RoomModel();
                    model.RoomID = Convert.ToInt32(reader["RoomID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.RoomTypeID = Convert.ToInt32(reader["RoomTypeID"]);
                    model.StatusID = Convert.ToInt32(reader["StatusID"]);
                    model.RoomImage = reader["RoomImage"].ToString();
                    model.TypeName = reader["TypeName"].ToString();
                    model.Description = reader["Description"].ToString();
                    model.PricePerDay = Convert.ToDecimal(reader["PricePerDay"]);
                    model.Status = reader["Status"].ToString();
                    model.UserName = reader["UserName"].ToString();
                    model.ChildCapacity = Convert.ToInt32(reader["ChildCapacity"]);
                    model.AdultCapacity = Convert.ToInt32(reader["AdultCapacity"]);
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
        #region MST_Room_DeleteByRoomID
        public bool MST_Room_DeleteByRoomID(int RoomID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Room_DeleteByRoomID");
                db.AddInParameter(cmd, "@RoomID", SqlDbType.Int, RoomID);
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
        #region MST_Room_SelectByRoomID
        public LOC_RoomModel MST_Room_SelectByRoomID(int RoomID)
        {
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Room_SelectByRoomID");
            db.AddInParameter(cmd, "@RoomID", SqlDbType.Int, RoomID);
            LOC_RoomModel model = new LOC_RoomModel();
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    model.RoomID = Convert.ToInt32(reader["RoomID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.RoomTypeID = Convert.ToInt32(reader["RoomTypeID"]);
                    model.StatusID = Convert.ToInt32(reader["StatusID"]);
                    model.RoomImage = reader["RoomImage"].ToString();
                    model.TypeName = reader["TypeName"].ToString();
                    model.Description = reader["Description"].ToString();
                    model.PricePerDay = Convert.ToDecimal(reader["PricePerDay"]);
                    model.Status = reader["Status"].ToString();
                    model.UserName = reader["UserName"].ToString();
                    model.ChildCapacity = Convert.ToInt32(reader["ChildCapacity"]);
                    model.AdultCapacity = Convert.ToInt32(reader["AdultCapacity"]);
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                }
            }
            return model;
        }
        #endregion
        #region MST_Room_Add
        public bool MST_Room_Add(LOC_RoomModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Room_InsertRecord");
                db.AddInParameter(cmd, "@RoomTypeID", SqlDbType.Int, model.RoomTypeID);
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, CommonVariables.UserID());
                db.AddInParameter(cmd, "@StatusID", SqlDbType.Int, model.StatusID);
                db.AddInParameter(cmd, "@RoomImage", SqlDbType.VarChar, model.RoomImage);
                db.AddInParameter(cmd, "@AdultCapacity", SqlDbType.Int, model.AdultCapacity);
                db.AddInParameter(cmd, "@ChildCapacity", SqlDbType.Int, model.ChildCapacity);
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
        #region MST_Room_Update
        public bool MST_Room_Update(LOC_RoomModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Room_UpdateRecord");
                db.AddInParameter(cmd, "@RoomID", SqlDbType.Int, model.RoomID);
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, CommonVariables.UserID());
                db.AddInParameter(cmd, "@RoomTypeID", SqlDbType.Int, model.RoomTypeID);
                db.AddInParameter(cmd, "@StatusID", SqlDbType.Int, model.StatusID);
                db.AddInParameter(cmd, "@RoomImage", SqlDbType.VarChar, model.RoomImage);
                db.AddInParameter(cmd, "@AdultCapacity", SqlDbType.Int, model.AdultCapacity);
                db.AddInParameter(cmd, "@ChildCapacity", SqlDbType.Int, model.ChildCapacity);
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
        #region MST_Room_Search
        public List<LOC_RoomModel> MST_Room_Search(string TypeName, string Status,int child,int adult)
        {
            List<LOC_RoomModel> list = new List<LOC_RoomModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Role_Filter");
            db.AddInParameter(cmd, "@TypeName", SqlDbType.VarChar, TypeName);
            db.AddInParameter(cmd, "@Status", SqlDbType.VarChar, Status);
            db.AddInParameter(cmd, "@child", SqlDbType.Int, child);
            db.AddInParameter(cmd, "@Adult", SqlDbType.Int, adult);
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_RoomModel model = new LOC_RoomModel();
                    model.RoomID = Convert.ToInt32(reader["RoomID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.RoomTypeID = Convert.ToInt32(reader["RoomTypeID"]);
                    model.StatusID = Convert.ToInt32(reader["StatusID"]);
                    model.RoomImage = reader["RoomImage"].ToString();
                    model.TypeName = reader["TypeName"].ToString();
                    model.Status = reader["Status"].ToString();
                    model.UserName = reader["UserName"].ToString();
                    model.ChildCapacity = Convert.ToInt32(reader["ChildCapacity"]);
                    model.AdultCapacity = Convert.ToInt32(reader["AdultCapacity"]);
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
