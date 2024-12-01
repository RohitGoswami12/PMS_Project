using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Model
{
    public class AssSubmit
    {
        [Key]
        public int AssSubmitId { get; set; }
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public UserDetails UserDetails { get; set; }
    }
}
