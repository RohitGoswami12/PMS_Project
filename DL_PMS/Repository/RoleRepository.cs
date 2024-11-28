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

    public class RoleRepository : IRoleRepository
    {
        PMS_Context _context = new PMS_Context();
        public List<RoleDetails> AllRoles()
        {
            List<RoleDetails> RoleDetails = new List<RoleDetails>();

            try
            {
                RoleDetails = _context.RoleDetails.ToList();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return RoleDetails;
        }
        public string AddRoles(RoleDetails roles)
        {
            string msg = "";
            var role = new RoleDetails
            {
                RoleName = roles.RoleName,
                Description = roles.Description,
                CreatedBy = "Admin"

            };
            try
            {
                _context.RoleDetails.Add(role);
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
