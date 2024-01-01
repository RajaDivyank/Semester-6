using Hotel_Management.Areas.Role.Models;
using Hotel_Management.DAL;

namespace Hotel_Management.BAL
{
    public class Role_BALBase
    {
        #region MST_Role_SelectAll
        public List<LOC_RoleModel> MST_Role_SelectAll()
        {
            Role_DALBase dal = new Role_DALBase();
            return dal.MST_Role_SelectAll();
        }
        #endregion
        #region MST_Role_SelectByRoleID
        public LOC_RoleModel MST_Role_SelectByRoleID(int RoleID)
        {
            Role_DALBase dal = new Role_DALBase();
            LOC_RoleModel role = dal.MST_Role_SelectByRoleID(RoleID);
            return role;
        }
        #endregion
        #region MST_Role_DeleteByRoleID
        public bool MST_Role_DeleteByRoleID(int RoleID)
        {
            Role_DALBase dal = new Role_DALBase();
            return dal.MST_Role_DeleteByRoleID(RoleID);
        }
        #endregion
        #region MST_Role_Add
        public bool MST_Role_Add(LOC_RoleModel model)
        {
            Role_DALBase dal = new Role_DALBase();
            return dal.MST_Role_Add(model);
        }
        #endregion
        #region MST_Role_Update

        public bool MST_Role_Update(LOC_RoleModel model)
        {
            Role_DALBase dal = new Role_DALBase();
            return dal.MST_Role_Update(model);
        }
        #endregion
        #region MST_Role_Search
        public List<LOC_RoleModel> MST_Role_Search(string Role)
        {
            Role_DALBase dal = new Role_DALBase();
            return dal.MST_Role_Search(Role);
        }
        #endregion
    }
}
