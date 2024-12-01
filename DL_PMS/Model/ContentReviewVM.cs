using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Model
{
    public class ContentReviewVM
    {
        public int Id { get; set; }
        public int AssId { get; set; }
        public string AssName { get; set; }
        public List<Assessment> Assessments { get; set; }
        public List<CaseStudyDetailsVM> CaseStudyVM { get; set; }
    }
}
