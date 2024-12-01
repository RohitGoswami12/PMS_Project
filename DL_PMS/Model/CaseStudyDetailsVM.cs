using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Model
{
    public class CaseStudyDetailsVM
    {
        public CaseStudyDetails CaseStudyDetails { get; set; }
        public List<CaseStudySolutions> CaseStudySolutions { get; set; }
    }
}
