using Hotel_Management.Areas.Hotel.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management.Areas.User.Models;

namespace Hotel_Management.DAL
{
    public class User_DALBase : DAL_Helper
    {
        #region MST_UserSelectAll
        public List<LOC_UserModel> MST_User_SelectAll()
        {
            List<LOC_UserModel> list = new List<LOC_UserModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_User_SelectAll");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    LOC_UserModel model = new LOC_UserModel();
                    model.UserID = Convert.ToInt32(reader["UserID"]);
                    model.UserName = reader["UserName"].ToString();
                    model.UserNumber = reader["UserNumber"].ToString();
                    model.Email = reader["Email"].ToString();
                    model.Password = reader["Password"].ToString();
                    model.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                    model.IsAdmin = Convert.ToBoolean(reader["IsAdmin"].ToString());
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
