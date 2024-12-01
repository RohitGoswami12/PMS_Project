using DL_PMS.Abstract;
using DL_PMS.Model;
using DL_PMS.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace PMS_Project.Controllers
{
    public class UserController : Controller
    {

        IUserRepository obj = new UserRepository();
        IRoleRepository _obj = new RoleRepository();
        PMS_Context _context = new PMS_Context();

        public IActionResult HomePage()
        {
            return View();
        }

        [Authorize]
        public IActionResult Userlist()
        {
            List<UserDetails> users = obj.AllUsers();
            return View(users);
        }

        
        [HttpGet]
        [Authorize]
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
        [Authorize]
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
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                // Fetch the user details from the database using the UserId
                var user = _context.UserDetails
                            .Where(e => e.UserId == model.UserId)
                            .SingleOrDefault();

                if (user != null)
                {
                    // Check if the UserId and Password are valid
                    bool IsValid = (user.UserId == model.UserId && user.Password == model.Password); // Ensure passwords are hashed in production!

                    if (IsValid)
                    {
                        // Fetch user's role from the RoleDetails table (assuming RoleId is in UserDetails)
                        var userRole = _context.RoleDetails
                                        .Where(r => r.RoleId == user.RoleId)
                                        .Select(r => r.RoleName) // Assuming RoleName stores the role
                                        .SingleOrDefault();

                        if (userRole != null)
                        {
                            // Create claims for the authenticated user
                            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserId),   // Add username claim
                        new Claim(ClaimTypes.Role, userRole)       // Add role claim
                    };

                            // Create the identity using the claims and authentication scheme
                            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            // Create the principal for the user
                            var principal = new ClaimsPrincipal(identity);

                            // Sign in the user with the authentication scheme
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                            // Store the current user's role in session
                            HttpContext.Session.SetString("CurrRole", userRole);

                            // Redirect to homepage or another role-specific page
                            return RedirectToAction("HomePage");
                        }
                        else
                        {
                            // Role not found, handle the error
                            TempData["Error"] = "User role not found.";
                            return View(model);
                        }
                    }
                    else
                    {
                        // Invalid password
                        TempData["Error1"] = "Invalid password.";
                        return View(model);
                    }
                }
                else
                {
                    // User not found
                    TempData["Error2"] = "UserId not found.";
                    return View(model);
                }
            }
            else
            {
                // If model validation fails, return the view with errors
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // Helps prevent CSRF attacks
        public async Task<IActionResult> Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirect to the home page or login page after logging out
            return RedirectToAction("Index", "Home"); // Change to your desired action
        }
        [HttpGet]
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult ChangePassword(ChangePasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var data = _context.UserDetails.Where(e => e.UserId == model.UserId).SingleOrDefault();
                if (data != null)
                {
                    if (data.Password == model.OldPassword)
                    {
                        data.Password = model.NewPassword;
                        _context.SaveChanges();
                        return RedirectToAction("Login");

                    }
                    else
                    {
                        TempData["Error1"] = "Old password is incorrect.";
                    }
                }
                else
                {
                    TempData["Error2"] = "UserId not found.";
                }
            }

            return View(model);
        }
    }
}
