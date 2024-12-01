using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Model
{
    public class CompetencyDetails
    {
        [Key]
        public int CompId { get; set; }
        public string CompName { get; set; }
    }
}
