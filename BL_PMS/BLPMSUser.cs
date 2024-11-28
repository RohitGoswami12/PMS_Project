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
    public class BLPMSUser
    {
        IUserRepository _repo = new UserRepository();
        PMS_Context _Context = new PMS_Context();

        public List<UserDetails> AllUsers()
        {
            List<UserDetails> userDetails = new List<UserDetails>();

            userDetails = _repo.AllUsers();

            return userDetails;
        }

        public string AddUsers(RegistrationVM register)
        {
            string msg = _repo.AddUsers(register);
            if (msg == "Success")
            {
                return "Success";
            }

            return "Failed";
        }

        
    }
}
