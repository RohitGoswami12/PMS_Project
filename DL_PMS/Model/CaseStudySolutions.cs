using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Model
{
    public class CaseStudySolutions
    {
        [Key]
        public int CSSID { get; set; }
        [Required]
        public string Solution { get; set; }
        [ForeignKey("CSID")]
        public int CSID { get; set; }
        [ForeignKey("CompedencyID")]
        public int CompedencyID { get; set; }
    }
}
