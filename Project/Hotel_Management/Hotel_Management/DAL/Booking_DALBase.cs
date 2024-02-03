using Hotel_Management.Areas.Room.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management.Areas.Booking.Models;

namespace Hotel_Management.DAL
{
    public class Booking_DALBase : DAL_Helper
    {
        #region MST_Booking_SelectAll
        public List<LOC_BookingModel> MST_Booking_SelectAll()
        {
            List<LOC_BookingModel> list = new List<LOC_BookingModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Booking_SelectAll");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_BookingModel model = new LOC_BookingModel();
                    model.BookingID = Convert.ToInt32(reader["BookingID"]);
                    model.RoomID = Convert.ToInt32(reader["RoomID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.CheckIn = Convert.ToDateTime(reader["CheckIn"]);
                    model.CheckOut = Convert.ToDateTime(reader["CheckOut"]);
                    model.TotalDays = Convert.ToInt32(reader["TotalDays"]);
                    model.RegistrationName = reader["RegistrationName"].ToString();
                    model.MobileNumber = reader["MobileNumber"].ToString();
                    model.IdProofName = reader["IdProofName"].ToString();
                    model.IdProofphoto = reader["IdProofphoto"].ToString();
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
        #region MST_Booking_DeleteByBookingID
        public bool MST_Booking_DeleteByBookingID(int BookingID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Booking_DeleteByBookingID");
                db.AddInParameter(cmd, "@BookingID", SqlDbType.Int, BookingID);
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
        #region MST_Booking_SelectByBookingID
        public LOC_BookingModel MST_Booking_SelectByBookingID(int BookingID)
        {
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Booking_SelectByBookingID");
            db.AddInParameter(cmd, "@BookingID", SqlDbType.Int, BookingID);
            LOC_BookingModel model = new LOC_BookingModel();
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    model.BookingID = Convert.ToInt32(reader["BookingID"]);
                    model.RoomID = Convert.ToInt32(reader["RoomID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.CheckIn = Convert.ToDateTime(reader["CheckIn"]);
                    model.CheckOut = Convert.ToDateTime(reader["CheckOut"]);
                    model.TotalDays = Convert.ToInt32(reader["TotalDays"]);
                    model.RegistrationName = reader["RegistrationName"].ToString();
                    model.MobileNumber = reader["MobileNumber"].ToString();
                    model.IdProofName = reader["IdProofName"].ToString();
                    model.IdProofphoto = reader["IdProofphoto"].ToString();
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                }
            }
            return model;
        }
        #endregion
        #region MST_Booking_Add
        public bool MST_Booking_Add(LOC_BookingModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Booking_InsertRecord");
                db.AddInParameter(cmd, "@RoomID", SqlDbType.Int, model.RoomID);
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, model.UserID);
                db.AddInParameter(cmd, "@CheckOut", SqlDbType.DateTime, model.CheckOut);
                db.AddInParameter(cmd, "@CheckIn", SqlDbType.DateTime, model.CheckIn);
                db.AddInParameter(cmd, "@TotalDays", SqlDbType.Int, model.TotalDays);
                db.AddInParameter(cmd, "@RegistrationName", SqlDbType.VarChar, model.RegistrationName);
                db.AddInParameter(cmd, "@MobileNumber", SqlDbType.VarChar, model.MobileNumber);
                db.AddInParameter(cmd, "@IdProofName", SqlDbType.VarChar, model.IdProofName);
                db.AddInParameter(cmd, "@IdProofphoto", SqlDbType.VarChar, model.IdProofphoto);
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
        #region MST_Booking_Update
        public bool MST_Booking_Update(LOC_BookingModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Booking_UpdateRecord");
                db.AddInParameter(cmd, "@BookingID", SqlDbType.Int, model.BookingID);
                db.AddInParameter(cmd, "@RoomID", SqlDbType.Int, model.RoomID);
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, model.UserID);
                db.AddInParameter(cmd, "@CheckOut", SqlDbType.DateTime, model.CheckOut);
                db.AddInParameter(cmd, "@CheckIn", SqlDbType.DateTime, model.CheckIn);
                db.AddInParameter(cmd, "@TotalDays", SqlDbType.Int, model.TotalDays);
                db.AddInParameter(cmd, "@RegistrationName", SqlDbType.VarChar, model.RegistrationName);
                db.AddInParameter(cmd, "@MobileNumber", SqlDbType.VarChar, model.MobileNumber);
                db.AddInParameter(cmd, "@IdProofName", SqlDbType.VarChar, model.IdProofName);
                db.AddInParameter(cmd, "@IdProofphoto", SqlDbType.VarChar, model.IdProofphoto);
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
