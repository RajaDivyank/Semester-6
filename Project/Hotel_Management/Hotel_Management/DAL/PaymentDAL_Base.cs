using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management.Areas.Payment.Models;
using Hotel_Management.BAL;

namespace Hotel_Management.DAL
{
    public class PaymentDAL_Base : DAL_Helper
    {
        #region MST_Payment_SelectAll
        public List<LOC_PaymentModel> MST_Payment_SelectAll()
        {
            List<LOC_PaymentModel> list = new List<LOC_PaymentModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Payment_SelectAll");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_PaymentModel model = new LOC_PaymentModel();
                    model.PaymentID = Convert.ToInt32(reader["PaymentID"]);
                    model.BookingID = Convert.ToInt32(reader["BookingID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                    model.Amount = Convert.ToDecimal(reader["Amount"]);
                    model.TotalDays = Convert.ToInt32(reader["TotalDays"]);
                    model.Method = reader["Method"].ToString();
                    model.PaymentDate = Convert.ToDateTime(reader["PaymentDate"]);
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
        #region MST_Payment_SelectByPaymentID
        public LOC_PaymentModel MST_Payment_SelectByPaymentID(int PaymentID)
        {
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Payment_SelectByPaymentID");
            db.AddInParameter(cmd, "@PaymentID", SqlDbType.Int, PaymentID);
            LOC_PaymentModel model = new LOC_PaymentModel();
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    model.PaymentID = Convert.ToInt32(reader["PaymentID"]);
                    model.BookingID = Convert.ToInt32(reader["BookingID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                    model.Amount = Convert.ToDecimal(reader["Amount"]);
                    model.TotalDays = Convert.ToInt32(reader["TotalDays"]);
                    model.Method = reader["Method"].ToString();
                    model.PaymentDate = Convert.ToDateTime(reader["PaymentDate"]);
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                }
            }
            return model;
        }
        #endregion
        #region MST_Payment_DeleteByPaymentID
        public bool MST_Payment_DeleteByPaymentID(int PaymentID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Payment_DeleteByPaymentID");
                db.AddInParameter(cmd, "@PaymentID", SqlDbType.Int, PaymentID);
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
        #region MST_Payment_Add
        public bool MST_Payment_Add(LOC_PaymentModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Payment_InsertRecord");
                db.AddInParameter(cmd, "@BookingID", SqlDbType.Int, model.BookingID);
                db.AddInParameter(cmd, "@PaymentMethodID", SqlDbType.Int, model.PaymentMethodID);
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, CommonVariables.UserID());
                db.AddInParameter(cmd, "@Amount", SqlDbType.Decimal, model.Amount);
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
        #region MST_Payment_Update
        public bool MST_Payment_Update(LOC_PaymentModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Payment_UpdateRecord");
                db.AddInParameter(cmd, "@PaymentID", SqlDbType.Int, model.PaymentID);
                db.AddInParameter(cmd, "@BookingID", SqlDbType.Int, model.BookingID);
                db.AddInParameter(cmd, "@PaymentMethodID", SqlDbType.Int, model.PaymentMethodID);
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, CommonVariables.UserID());
                db.AddInParameter(cmd, "@Amount", SqlDbType.Decimal, model.Amount);
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
