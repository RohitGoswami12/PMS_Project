using DL_PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Abstract
{
    public interface IContentReviewRepository
    {
        List<Assessment> GetallAssessment();

        List<ContentEditVM> GetCaseStudiesById(int AssId);
        Assessment GetAssessment(int AssId);

        CaseStudyDetails GetCaseStudy(int CSId);
        List<CompetencyDetails> GetAllCompetency();
        List<CaseStudySolutions> GetDetailsofCaseStudy(int CaseStudyId);
        string EditCaseStudySolu(ContentEditVM createcntnt);
    }
}
