using DL_PMS.Abstract;
using DL_PMS.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Repository
{
    public class UserRepository : IUserRepository
    {
        PMS_Context _context = new PMS_Context();

        public List<UserDetails> AllUsers()
        {
            List<UserDetails> userDetails = new List<UserDetails>();
            try
            {
                userDetails = _context.UserDetails.ToList();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return userDetails;
        }
        public string AddUsers(RegistrationVM register)
        {
            string msg = "";
            var user = new UserDetails
            {
                Name = register.Name,
                Password = register.Password,
                UserId = register.UserId,
                EmailAddress = register.EmailAddress,
                EmployeeId = register.EmployeeId,
                RoleId = register.RoleId,
                IsActive = register.IsActive,
                CreatedBy = "Admin",
                
            };
            try
            {
                _context.UserDetails.Add(user);
                _context.SaveChanges();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
        
    }
}
