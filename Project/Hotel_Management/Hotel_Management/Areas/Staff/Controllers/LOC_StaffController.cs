using Hotel_Management.Areas.Staff.Models;
using Hotel_Management.DAL;
using Hotel_Management.BAL;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using static NuGet.Packaging.PackagingConstants;

namespace Hotel_Management.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class LOC_StaffController : Controller
    {
        #region MST_Staff_SelectAll
        public IActionResult StaffView()
        {
            Staff_BALBase bal = new Staff_BALBase();
            return View(bal.MST_Staff_SelectAll());
        }
        #endregion
        #region MST_Staff_SelectByStaffID
        public IActionResult StaffDetail(int StaffID)
        {
            Staff_BALBase bal = new Staff_BALBase();
            LOC_StaffModel model = bal.MST_Staff_SelectByStaffID(StaffID);
            return View(model);

        }
        #endregion
        #region MST_Staff_DeleteByStaffID
        public IActionResult DeleteByStaffID(int StaffID)
        {
            try
            {
                TempData["Message"] = "Staff Delete Successfully";
                Staff_BALBase bal = new Staff_BALBase();
                bool deleted = bal.MST_Staff_DeleteByStaffID(StaffID);
            }
            catch { }
            return RedirectToAction("StaffView");
        }
        #endregion
        #region MST_Staff_AddEdit
        public IActionResult StaffAddEdit(int StaffID)
        {
            Role_DALBase roledal = new Role_DALBase();
            if (StaffID == 0)
            {
                LOC_StaffModel model = new LOC_StaffModel();
                model.roles = roledal.MST_Role_SelectAll();
                return View(model);
            }
            else
            {
                Staff_BALBase bal = new Staff_BALBase();
                LOC_StaffModel model = bal.MST_Staff_SelectByStaffID(StaffID);
                model.roles = roledal.MST_Role_SelectAll();
                TempData["IDProofPhotoPath"] = model.IDProofPhotoPath;
                TempData["StaffImage"] = model.StaffImage;
                TempData["Message"] = "Staff Not Edit Successfully";
                return View(model);
            }
        }
        #endregion
        #region SaveForAddEdit
        public IActionResult SaveForAddEdit(LOC_StaffModel model)
        {
            if (model.StaffID != 0)
            {
                if (model.IDProofPhotoFile == null && TempData["IDProofPhotoPath"] != null)
                {
                    model.IDProofPhotoPath = TempData["IDProofPhotoPath"].ToString();
                }
                if (model.StaffImageFile == null && TempData["StaffImage"] != null)
                {
                    model.StaffImage = TempData["StaffImage"].ToString();
                }
            }
            if (model.IDProofPhotoFile != null)
            {
                string filePath =
               System.IO.Path.GetExtension(model.IDProofPhotoFile.FileName);

                string directoryPath = @"D:\Semester-6\Project\Hotel_Management\Hotel_Management\wwwroot\Images";

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string folderPath = Path.Combine("wwwroot/Images/", model.IDProofPhotoFile.FileName);
                using (FileStream fs = System.IO.File.Create(folderPath))
                {
                    model.IDProofPhotoFile.CopyTo(fs);
                }
                model.IDProofPhotoPath = "/Images/" + model.IDProofPhotoFile.FileName;
            }
            if (model.StaffImageFile != null)
            {
                string filePath =
               System.IO.Path.GetExtension(model.StaffImageFile.FileName);

                string directoryPath = @"D:\Semester-6\Project\Hotel_Management\Hotel_Management\wwwroot\Images";

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string folderPath = Path.Combine("wwwroot/Images/", model.StaffImageFile.FileName);
                using (FileStream fs = System.IO.File.Create(folderPath))
                {
                    model.StaffImageFile.CopyTo(fs);
                }
                model.StaffImage = "/Images/" + model.StaffImageFile.FileName;
            }
            bool ans = false;

            Staff_BALBase bal = new Staff_BALBase();
            if(ModelState.IsValid)
            {
                if (model.StaffID != null)
                {
                    /*TempData["Message"] = "Staff Edit Successfully";*/
                    ans = bal.MST_Staff_Update(model);
                }
                else
                {
                    TempData["Message"] = "Staff Add Successfully";
                    ans = bal.MST_Staff_Add(model);
                }
            }
            if (ans)
            {
                TempData["Bool"] = true;
                return RedirectToAction("StaffView");
            }
            else
            {
                TempData["Bool"] = false;
                return RedirectToAction("StaffAddEdit");
            }
        }
        #endregion
        #region MST_Staff_Search
        public IActionResult StaffSearch(string FirstName, string StaffEmail, string Role)
        {
            Staff_BALBase bal = new Staff_BALBase();
            return View("StaffView", bal.MST_Staff_Search(FirstName, StaffEmail, Role));
        }
        #endregion
    }
}
