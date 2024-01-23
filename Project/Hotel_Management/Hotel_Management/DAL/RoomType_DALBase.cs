using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management.Areas.Roomtype.Models;

namespace Hotel_Management.DAL
{
    public class RoomType_DALBase : DAL_Helper
    {
        #region MST_RoomType_SelectAll
        public List<LOC_RoomTypeModel> MST_RoomType_SelectAll()
        {
            List<LOC_RoomTypeModel> list = new List<LOC_RoomTypeModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_RoomType_SelectAll");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_RoomTypeModel model = new LOC_RoomTypeModel();
                    model.RoomTypeID = Convert.ToInt32(reader["RoomTypeID"]);
                    model.TypeName = reader["TypeName"].ToString();
                    model.Description = reader["Description"].ToString();
                    model.PricePerDay = Convert.ToDecimal(reader["PricePerDay"]);
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
        #region MST_RoomType_SelectByRoomTypeID
        public LOC_RoomTypeModel MST_RoomType_SelectByRoomTypeID(int RoomTypeID)
        {
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_RoomType_SelectByRoomTypeID");
            db.AddInParameter(cmd, "@RoomTypeID", SqlDbType.Int, RoomTypeID);
            LOC_RoomTypeModel model = new LOC_RoomTypeModel();
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    model.RoomTypeID = Convert.ToInt32(reader["RoomTypeID"]);
                    model.TypeName = reader["TypeName"].ToString();
                    model.Description = reader["Description"].ToString();
                    model.PricePerDay = Convert.ToDecimal(reader["PricePerDay"]);
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                }
            }
            return model;
        }
        #endregion
        #region MST_RoomType_DeleteByRoomTypeID
        public bool MST_RoomType_DeleteByRoomTypeID(int RoomTypeID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_RoomType_DeleteByRoomTypeID");
                db.AddInParameter(cmd, "@RoomTypeID", SqlDbType.Int, RoomTypeID);
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
        #region MST_RoomType_Add
        public bool MST_RoomType_Add(LOC_RoomTypeModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_RoomType_InsertRecord");
                db.AddInParameter(cmd, "@TypeName", SqlDbType.VarChar, model.TypeName);
                db.AddInParameter(cmd, "@Description", SqlDbType.VarChar, model.Description);
                db.AddInParameter(cmd, "@PricePerDay", SqlDbType.Decimal, model.PricePerDay);
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
        #region MST_RoomType_Update
        public bool MST_RoomType_Update(LOC_RoomTypeModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_RoomType_UpdateRecord");
                db.AddInParameter(cmd, "@RoomTypeID", SqlDbType.Int, model.RoomTypeID);
                db.AddInParameter(cmd, "@TypeName", SqlDbType.VarChar, model.TypeName);
                db.AddInParameter(cmd, "@Description", SqlDbType.VarChar, model.Description);
                db.AddInParameter(cmd, "@PricePerDay", SqlDbType.Decimal, model.PricePerDay);
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
        #region MST_RoomType_Search
        public List<LOC_RoomTypeModel> MST_RoomType_Search(string TypeName , decimal PricePerDay)
        {
            List<LOC_RoomTypeModel> list = new List<LOC_RoomTypeModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_RoomType_Filter");
            db.AddInParameter(cmd, "@TypeName", SqlDbType.VarChar, TypeName);
            db.AddInParameter(cmd, "@PricePerDay", SqlDbType.Decimal, PricePerDay);
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_RoomTypeModel model = new LOC_RoomTypeModel();
                    model.RoomTypeID = Convert.ToInt32(reader["RoomTypeID"]);
                    model.TypeName = reader["TypeName"].ToString();
                    model.PricePerDay = Convert.ToDecimal(reader["PricePerDay"]);
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                }
            }
            return list;
        }
        #endregion
    }
}
