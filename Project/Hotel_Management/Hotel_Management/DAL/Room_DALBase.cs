using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management.Areas.Room.Models;

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
                    model.HotelID = Convert.ToInt32(reader["HotelID"]);
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.RoomTypeID = Convert.ToInt32(reader["RoomTypeID"]);
                    model.StatusID = Convert.ToInt32(reader["StatusID"]);
                    model.RoomImage = reader["RoomImage"].ToString();
                    model.TypeName = reader["TypeName"].ToString();
                    model.Status = reader["Status"].ToString();
                    model.UserName = reader["UserName"].ToString();
                    model.HotelName = reader["HotelName"].ToString();
                    model.ChildCapacity = Convert.ToInt32(reader["ChildCapacity"]);
                    model.AdultCapacity = Convert.ToInt32(reader["AdultCapacity"]);
                    model.CheckInDate = Convert.ToDateTime(reader["CheckInDate"]);
                    model.CheckOutDate = Convert.ToDateTime(reader["CheckOutDate"]);
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
