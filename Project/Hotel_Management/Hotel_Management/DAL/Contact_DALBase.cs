using Hotel_Management.Areas.Contact.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management.BAL;

namespace Hotel_Management.DAL
{
    public class Contact_DALBase : DAL_Helper
    {
        #region MST_Contact_SelectAll
        public List<LOC_ContactModel> MST_Contact_SelectAll()
        {
            List<LOC_ContactModel> list = new List<LOC_ContactModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Contact_SelectAll");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_ContactModel model = new LOC_ContactModel();
                    model.ContactID = Convert.ToInt32(reader["ContactID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.Name = reader["Name"].ToString();
                    model.Email = reader["Email"].ToString();
                    model.Subject = reader["Subject"].ToString();
                    model.Message = reader["Message"].ToString();
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
        #region MST_Contact_SelectByContactID
        public LOC_ContactModel MST_Contact_SelectByContactID(int ContactID)
        {
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Contact_SelectByContactID");
            db.AddInParameter(cmd, "@ContactID", SqlDbType.Int, ContactID);
            LOC_ContactModel model = new LOC_ContactModel();
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    model.ContactID = Convert.ToInt32(reader["ContactID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.Name = reader["Name"].ToString();
                    model.Email = reader["Email"].ToString();
                    model.Subject = reader["Subject"].ToString();
                    model.Message = reader["Message"].ToString();
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                }
            }
            return model;
        }
        #endregion
        #region MST_Contact_DeleteByContactID
        public bool MST_Contact_DeleteByContactID(int ContactID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Contact_DeleteByContactID");
                db.AddInParameter(cmd, "@ContactID", SqlDbType.Int, ContactID);
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
        #region MST_Contact_Add
        public bool MST_Contact_Add(LOC_ContactModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Contact_InsertRecord");
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, CommonVariables.UserID());
                db.AddInParameter(cmd, "@Name", SqlDbType.VarChar, model.Name);
                db.AddInParameter(cmd, "@Email", SqlDbType.VarChar, model.Email);
                db.AddInParameter(cmd, "@Subject", SqlDbType.VarChar, model.Subject);
                db.AddInParameter(cmd, "@Message", SqlDbType.VarChar, model.Message);
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
        #region MST_Contact_Update
        public bool MST_Contact_Update(LOC_ContactModel model)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_Contact_UpdateRecord");
                db.AddInParameter(cmd, "@ContactID", SqlDbType.Int, CommonVariables.UserID());
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, model.UserID);
                db.AddInParameter(cmd, "@Name", SqlDbType.VarChar, model.Name);
                db.AddInParameter(cmd, "@Email", SqlDbType.VarChar, model.Email);
                db.AddInParameter(cmd, "@Subject", SqlDbType.VarChar, model.Subject);
                db.AddInParameter(cmd, "@Message", SqlDbType.VarChar, model.Message);
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
        #region MST_Contact_Search
        public List<LOC_ContactModel> MST_Contact_Search(string? Name, string? Email)
        {
            List<LOC_ContactModel> list = new List<LOC_ContactModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Contact_Filter");
            db.AddInParameter(cmd, "@Name", SqlDbType.VarChar, Name);
            db.AddInParameter(cmd, "@Email", SqlDbType.Decimal, Email);
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_ContactModel model = new LOC_ContactModel();
                    model.ContactID = Convert.ToInt32(reader["ContactID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.Name = reader["Name"].ToString();
                    model.Email = reader["Email"].ToString();
                    model.Subject = reader["Subject"].ToString();
                    model.Message = reader["Message"].ToString();
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
