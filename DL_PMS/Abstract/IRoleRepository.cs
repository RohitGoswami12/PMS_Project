using DL_PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Abstract
{
    public interface IRoleRepository
    {
        public List<RoleDetails> AllRoles();
        public string AddRoles(RoleDetails roles);
    }
}
