using DL_PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Abstract
{
    public interface IUserRepository
    {
        public List<UserDetails> AllUsers();
        public string AddUsers(RegistrationVM register);
        
    }
}
