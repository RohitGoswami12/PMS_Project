using DL_PMS.Abstract;
using DL_PMS.Model;
using DL_PMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_PMS
{
    public class BLPMSReviewContent
    {
        IContentReviewRepository _repo = new ContentReviewRepository();
        PMS_Context _context = new PMS_Context();

        public List<Assessment> GetallUAssessment()
        {
            List<Assessment> AssessmentDetails = new List<Assessment>();

            AssessmentDetails = _repo.GetallAssessment();

            return AssessmentDetails;
        }
        //
        public List<ContentEditVM> GetallCasestudyDetail(int Assid)
        {
            List<ContentEditVM> CaseStudyList = new List<ContentEditVM>();
            CaseStudyList = _repo.GetCaseStudiesById(Assid);

            return CaseStudyList;
        }

        public Assessment GetAssessment(int Assid)
        {
            var Assessment = _repo.GetAssessment(Assid);
            return Assessment;
        }
        public List<CompetencyDetails> GetAllCompetency()
        {
            List<CompetencyDetails> competencies = new List<CompetencyDetails>();
            competencies = _repo.GetAllCompetency();
            return competencies;

        }

        public CaseStudyDetails GetCaseStudyById(int CaseId)
        {
            var comptency = _repo.GetCaseStudy(CaseId);
            return comptency;
        }

        public List<CaseStudySolutions> GetallSolutions(int caseStudyId)
        {
            List<CaseStudySolutions> caseStudy = new List<CaseStudySolutions>();
            caseStudy = _repo.GetDetailsofCaseStudy(caseStudyId);
            return caseStudy;
        }
        public string EditCaseStudySolu(ContentEditVM createcntnt)
        {
            string msg = _repo.EditCaseStudySolu(createcntnt);
            return msg;
        }
    }
}
