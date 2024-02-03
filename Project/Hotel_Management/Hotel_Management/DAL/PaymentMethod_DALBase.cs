using Hotel_Management.Areas.Role.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management.Areas.PaymentMethod.Models;

namespace Hotel_Management.DAL
{
    public class PaymentMethod_DALBase : DAL_Helper
    {
        #region MST_PaymentMethod_SelectAll
        public List<LOC_PaymentMethodModel> MST_PaymentMethod_SelectAll()
        {
            List<LOC_PaymentMethodModel> list = new List<LOC_PaymentMethodModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_PaymentMethod_SelectAll");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_PaymentMethodModel model = new LOC_PaymentMethodModel();
                    model.PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.Method = reader["Method"].ToString();
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
        #region MST_PaymentMethod_SelectByPaymentMethodID
        public LOC_PaymentMethodModel MST_PaymentMethod_SelectByPaymentMethodID(int PaymentMethodID)
        {
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_PaymentMethod_SelectByPaymentMethodID");
            db.AddInParameter(cmd, "@PaymentMethodID", SqlDbType.Int, PaymentMethodID);
            LOC_PaymentMethodModel model = new LOC_PaymentMethodModel();
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    model.PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.Method = reader["Method"].ToString();
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                }
            }
            return model;
        }
        #endregion
        #region MST_PaymentMethod_DeleteByPaymentMethodID
        public bool MST_PaymentMethod_DeleteByPaymentMethodID(int PaymentMethodID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_PaymentMethod_DeleteByPaymentMethodID");
                db.AddInParameter(cmd, "@PaymentMethodID", SqlDbType.Int, PaymentMethodID);
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
        #region MST_PaymentMethod_Add
        public bool MST_PaymentMethod_Add(LOC_PaymentMethodModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_PaymentMethod_InsertRecord");
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, model.UserID);
                db.AddInParameter(cmd, "@Method", SqlDbType.VarChar, model.Method);
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
        #region MST_PaymentMethod_Update
        public bool MST_PaymentMethod_Update(LOC_PaymentMethodModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_PaymentMethod_UpdateRecord");
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, model.UserID);
                db.AddInParameter(cmd, "@PaymentMethodID", SqlDbType.Int, model.PaymentMethodID);
                db.AddInParameter(cmd, "@Method", SqlDbType.VarChar, model.Method);
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
        #region MST_PaymentMethod_Search
        public List<LOC_PaymentMethodModel> MST_PaymentMethod_Search(string Method)
        {
            List<LOC_PaymentMethodModel> list = new List<LOC_PaymentMethodModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_PaymentMethod_Filter");
            db.AddInParameter(cmd, "@Method", SqlDbType.VarChar, Method);
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_PaymentMethodModel model = new LOC_PaymentMethodModel();
                    model.PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.Method = reader["Method"].ToString();
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
