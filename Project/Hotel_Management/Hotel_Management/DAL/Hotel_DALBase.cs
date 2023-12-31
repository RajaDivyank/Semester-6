using Hotel_Management.Areas.Hotel.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using System.Security.Policy;

namespace Hotel_Management.DAL
{
    public class Hotel_DALBase : DAL_Helper
    {
        #region MST_HotelSelectAll
        public List<LOC_HotelModel> MST_Hotel_SelectAll()
        {
            List<LOC_HotelModel> list = new List<LOC_HotelModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_LOC_Hotel_SelectAll");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_HotelModel model = new LOC_HotelModel();
                    model.HotelID = Convert.ToInt32(reader["HotelID"]);
                    model.HotelName = reader["HotelName"].ToString();
                    model.OwnerName = reader["OwnerName"].ToString();
                    model.HotelAddress = reader["HotelAddress"].ToString();
                    model.HotelEmail = reader["HotelEmail"].ToString();
                    model.HotelPhoneNumber = reader["HotelPhoneNumber"].ToString();
                    model.Rating = Convert.ToDecimal(reader["Rating"].ToString());
                    model.Created = Convert.ToDateTime(reader["Created"]);
                    model.Modified = Convert.ToDateTime(reader["Modified"]);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
        #region MST_HotelSelectByHotelID
        public bool MST_Hotel_DeleteByHotelID(int HotelID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnStr);
                DbCommand cmd = db.GetStoredProcCommand("PR_MST_Users_DeleteByUserID");
                db.AddInParameter(cmd, "@HotelID", SqlDbType.Int, HotelID);
                int noOfRows = db.ExecuteNonQuery(cmd);
                if (noOfRows > 0) { return true; }
                else { return false; }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
        #endregion
        #region MST_HotelSelectByHotelID
        public LOC_HotelModel MST_HotelSelectByHotelID(int HotelID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_LOC_Hotel_SelectByHotelID");
                sqlDatabase.AddInParameter(dbCommand, "@HotelID", SqlDbType.Int, HotelID);
                LOC_HotelModel model = new LOC_HotelModel();
                using (IDataReader reader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    if(reader.Read())
                    {
                        model.HotelID = Convert.ToInt32(reader["HotelID"].ToString());
                        model.HotelName = reader["HotelName"].ToString();
                        model.OwnerName = reader["OwnerName"].ToString();
                        model.HotelEmail = reader["HotelEmail"].ToString();
                        model.HotelAddress = reader["HotelAddress"].ToString();
                        model.HotelPhoneNumber = reader["HotelPhoneNumber"].ToString();
                        model.Rating = Convert.ToDecimal(reader["Rating"].ToString());
                        model.Created = Convert.ToDateTime((reader["Created"].ToString()));
                        model.Modified = Convert.ToDateTime((reader["Modified"].ToString()));
                    }
                }
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region MST_Hotel_Insert_Record
        public bool MST_Hotel_Insert_Record(LOC_HotelModel lOC_HotelModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_LOC_Hotel_Insert_Record");
                sqlDatabase.AddInParameter(dbCommand, "@HotelName", SqlDbType.VarChar, lOC_HotelModel.HotelName);
                sqlDatabase.AddInParameter(dbCommand, "@OwnerName", SqlDbType.VarChar, lOC_HotelModel.OwnerName);
                sqlDatabase.AddInParameter(dbCommand, "@HotelAddress", SqlDbType.VarChar, lOC_HotelModel.HotelAddress);
                sqlDatabase.AddInParameter(dbCommand, "@HotelEmail", SqlDbType.VarChar, lOC_HotelModel.HotelEmail);
                sqlDatabase.AddInParameter(dbCommand, "@HotelPhoneNumber", SqlDbType.VarChar, lOC_HotelModel.HotelPhoneNumber);
                sqlDatabase.AddInParameter(dbCommand, "@Rating", SqlDbType.Decimal, lOC_HotelModel.Rating);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
        #endregion

    }
}
