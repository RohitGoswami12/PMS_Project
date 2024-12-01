using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Model
{
    public class CaseStudyDetails
    {
        [Key]
        public int CsSID { get; set; }
        [Required]
        public string CaseStudy { get; set; }
        [ForeignKey("AssessmentId")]
        public int AssessmentId { get; set; }
        public bool? ReviewStatus { get; set; }
        public string? CreatedBy { get; set; }
    }
}
