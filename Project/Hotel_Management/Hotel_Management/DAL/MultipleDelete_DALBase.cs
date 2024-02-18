using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management.Models;

namespace Hotel_Management.DAL
{
    public class MultipleDelete_DALBase : DAL_Helper
    {
        #region MST_MD_SelectAll
        public List<MultipleDeleteModel> MST_MD_SelectAll()
        {
            List<MultipleDeleteModel> list = new List<MultipleDeleteModel>();
            SqlDatabase db = new SqlDatabase(ConnStr);
            DbCommand cmd = db.GetStoredProcCommand("PR_MD_SelectAll");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    MultipleDeleteModel model = new MultipleDeleteModel();
                    model.NameID = Convert.ToInt32(reader["NameID"]);
                    model.Name = reader["Name"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
    }
}
