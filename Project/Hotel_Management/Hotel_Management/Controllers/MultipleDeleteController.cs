using Hotel_Management.DAL;
using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    public class MultipleDeleteController : Controller
    {
        public IActionResult MultipleDeleteDemo()
        {
            MultipleDelete_DALBase dal = new MultipleDelete_DALBase();
            return View(dal.MST_MD_SelectAll());
        }
        public IActionResult DeleteMultiple(List<MultipleDeleteModel> list)
        {
            string str = "";
            foreach(MultipleDeleteModel model in list)
            {
                if(model.IsChecked)
                {
                    str += model.NameID+",";
                }
            }
            return View("MultipleDeleteDemo");
        }
    }
}
