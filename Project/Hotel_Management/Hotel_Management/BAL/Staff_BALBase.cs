using Hotel_Management.Areas.Staff.Models;
using Hotel_Management.Areas.User.Models;
using Hotel_Management.DAL;

namespace Hotel_Management.BAL
{
    public class Staff_BALBase
    {
        #region MST_Staff_SelectAll
        public List<LOC_StaffModel> MST_Staff_SelectAll()
        {
            Staff_DALBase dal = new Staff_DALBase();
            return dal.MST_Staff_SelectAll();
        }
        #endregion
        #region MST_Staff_SelectBYStaffID
        public LOC_StaffModel MST_Staff_SelectByStaffID(int StaffID)
        {
            Staff_DALBase dal = new Staff_DALBase();
            LOC_StaffModel staff = dal.MST_Staff_SelectByStaffID(StaffID);
            return staff;
        }
        #endregion
        #region MST_Staff_DeleteByStaffID
        public bool MST_Staff_DeleteByStaffID(int StaffID)
        {
            Staff_DALBase dal = new Staff_DALBase();
            return dal.MST_Staff_DeleteByStaffID(StaffID);
        }
        #endregion
        #region MST_Staff_Add
        public bool MST_Staff_Add(LOC_StaffModel model)
        {
            Staff_DALBase dal = new Staff_DALBase();
            return dal.MST_Staff_Add(model);
        }
        #endregion
        #region MST_Staff_Update

        public bool MST_Staff_Update(LOC_StaffModel model)
        {
            Staff_DALBase dal = new Staff_DALBase();
            return dal.MST_Staff_Update(model);
        }
        #endregion
    }
}
