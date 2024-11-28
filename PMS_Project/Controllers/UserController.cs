using DL_PMS.Abstract;
using DL_PMS.Model;
using DL_PMS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace PMS_Project.Controllers
{
    public class UserController : Controller
    {

        IUserRepository obj = new UserRepository();
        IRoleRepository _obj = new RoleRepository();
        PMS_Context _context = new PMS_Context();
        public IActionResult Userlist()
        {
            List<UserDetails> users = obj.AllUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult NewRegistration()
        {
            var roles = _obj.AllRoles();
            // Create a list of SelectListItem for the dropdown
            ViewBag.Roles = roles.Select(static r => new SelectListItem
            {
                Value = r.RoleId.ToString(),
                Text = r.RoleName
            }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult NewRegistration(RegistrationVM registration)
        {
            string msg = obj.AddUsers(registration);
            if (msg == "success")
            {
                return RedirectToAction("Userlist");
            }
            TempData["SuccessMsg"] = "Registration successfully done";
            return View(registration);
        }
    }
}
