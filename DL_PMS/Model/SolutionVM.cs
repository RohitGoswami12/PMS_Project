using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Model
{
    public class SolutionVM
    {
        public string SolutionText { get; set; }
        public int CompetencyId { get; set; }
        public List<CompetencyDetails> Competencies { get; set; }
    }
}
