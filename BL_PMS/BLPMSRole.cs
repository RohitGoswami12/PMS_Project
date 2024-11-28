using DL_PMS.Abstract;
using DL_PMS.Model;
using DL_PMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_PMS
{
    public class BLPMSRole
    {
        IRoleRepository _repo = new RoleRepository();
        PMS_Context _context = new PMS_Context();

        public List<RoleDetails> AllRoles()
        {
            List<RoleDetails> roleDetails = new List<RoleDetails>();

            roleDetails = _repo.AllRoles();

            return roleDetails;
        }

        public string AddRoles(RoleDetails roles)
        {
            string msg = _repo.AddRoles(roles);
            if (msg == "Success")
            {
                return "Success";
            }

            return "Failed";
        }
    }
}
