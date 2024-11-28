using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Model
{
    public class RegistrationVM
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string EmployeeId { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}
