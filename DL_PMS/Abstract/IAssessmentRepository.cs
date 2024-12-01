using DL_PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Abstract
{
    public interface IAssessmentRepository
    {
        List<Assessment> GetAllAssessmentList();
        string AddAssesssment(AssessmentVM asment);
        //void SendEmail(string toEmail, string subject, string body);
        List<CaseStudyDetails> AllCase();
        List<CaseStudySolutions> AllSolutions();
        List<CompetencyDetails> GetCompetency();
        string CreateContent(CreateContentVM content);
    }
}
