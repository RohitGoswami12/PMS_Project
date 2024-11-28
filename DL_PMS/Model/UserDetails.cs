using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Model
{
    [Table("UserDetail")]
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; } 
        public string EmailAddress { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
}
