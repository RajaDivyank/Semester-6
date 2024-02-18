using Hotel_Management.Models;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Hotel_Management.DAL
{
    public class DashboardCount_DALBase : DAL_Helper
    {
        #region MST_DashboardCount_SelectAll
        public List<DashboardCountModel> MST_DashboardCount_SelectAll()
        {
            List<DashboardCountModel> list = new List<DashboardCountModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_Dashboord_Count");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    DashboardCountModel model = new DashboardCountModel();
                    model.UserCount = Convert.ToInt32(reader["UserCount"]);
                    model.StaffCount = Convert.ToInt32(reader["StaffCount"]);
                    model.RoleNameCount = Convert.ToInt32(reader["RoleNameCount"]);
                    model.RoomTypeCount = Convert.ToInt32(reader["RoomTypeCount"]);
                    model.RoomStatusCount = Convert.ToInt32(reader["RoomStatusCount"]);
                    model.RoomCount = Convert.ToInt32(reader["RoomCount"]);
                    model.BookingCount = Convert.ToInt32(reader["BookingCount"]);
                    model.PaymentCount = Convert.ToInt32(reader["PaymentCount"]);
                    model.PaymentMethodCount = Convert.ToInt32(reader["PaymentMethodCount"]);
                    model.ContactCount = Convert.ToInt32(reader["ContactCount"]);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
    }
}
