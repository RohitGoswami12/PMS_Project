using DL_PMS.Abstract;
using DL_PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Repository
{
    public class ContentReviewRepository : IContentReviewRepository
    {
        PMS_Context _context = new PMS_Context();

        public List<Assessment> GetallAssessment()
        {
            List<Assessment> AssessmentDetails = new List<Assessment>();

            try
            {
                AssessmentDetails = _context.AssessmentDetails.ToList();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return AssessmentDetails;
        }

        public List<ContentEditVM> GetCaseStudiesById(int AssId)
        {
            List<ContentEditVM> CaseStudyDetails = new List<ContentEditVM>();
            List<CaseStudyDetails> CaseStudy = new List<CaseStudyDetails>();

            try
            {
                CaseStudy = _context.CaseStudyDetails.Where(a => a.AssessmentId == AssId).ToList();
                foreach (var c in CaseStudy)
                {
                    CaseStudyDetails.Add(new ContentEditVM
                    {
                        CaseStudyId = c.CsSID, // Assuming Id is the primary key
                        CaseStudy = c.CaseStudy // Assuming CaseStudy is the name
                    });
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return CaseStudyDetails;
        }
        public Assessment GetAssessment(int AssId)
        {
            var ass = _context.AssessmentDetails.FirstOrDefault(a => a.AssId == AssId);

            return ass;
        }

        public CaseStudyDetails GetCaseStudy(int CSId)
        {
            var caseDetails = _context.CaseStudyDetails.FirstOrDefault(a => a.CsSID == CSId);

            return caseDetails;
        }

        public List<CompetencyDetails> GetAllCompetency()
        {
            List<CompetencyDetails> CompetencyDetails = new List<CompetencyDetails>();

            try
            {
                CompetencyDetails = _context.CompetencyDetails.ToList();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return CompetencyDetails;
        }
        public List<CaseStudySolutions> GetDetailsofCaseStudy(int CaseStudyId)
        {
            List<CaseStudySolutions> caseStudies = new List<CaseStudySolutions>();
            try
            {
                caseStudies = _context.CaseStudySolutions.Where(solution => solution.CSID == CaseStudyId).ToList();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return caseStudies;
        }

        public string EditCaseStudySolu(ContentEditVM createcntnt)
        {
            string msg = "";
            var oldCaseStudyName = GetCaseStudy(createcntnt.CaseStudyId);
            try
            {
                if (oldCaseStudyName.CaseStudy != createcntnt.CaseStudy)
                {


                    var CsDetail = new CaseStudyDetails
                    {
                        CsSID = createcntnt.CaseStudyId,
                        CaseStudy = createcntnt.CaseStudy,
                        AssessmentId = createcntnt.AssID
                    };


                    // Save the case study to the database
                    _context.CaseStudyDetails.Update(CsDetail);
                    _context.SaveChanges(); // Save the CaseStudy first to generate an Id
                    msg = "Success";
                }


                var existingSolutions = GetDetailsofCaseStudy(createcntnt.CaseStudyId).ToList();
                // Update solutions and competencies
                var updatedSolutions = new List<CaseStudySolutions>
                {
        new CaseStudySolutions { Solution = createcntnt.Sol1, CompedencyID = createcntnt.CompId1, CSID = createcntnt.CaseStudyId },
        new CaseStudySolutions { Solution = createcntnt.Sol2, CompedencyID = createcntnt.CompId2, CSID = createcntnt.CaseStudyId },
        new CaseStudySolutions { Solution = createcntnt.Sol3, CompedencyID = createcntnt.CompId3, CSID = createcntnt.CaseStudyId },
        new CaseStudySolutions { Solution = createcntnt.Sol4, CompedencyID = createcntnt.CompId4, CSID = createcntnt.CaseStudyId }
    };

                // Loop through each updated solution
                for (int i = 0; i < updatedSolutions.Count; i++)
                {
                    var updatedSolution = updatedSolutions[i];
                    var existingSolution = existingSolutions.ElementAtOrDefault(i);

                    if (existingSolution != null)
                    {
                        // Check if the solution text or competency has changed
                        if (existingSolution.Solution != updatedSolution.Solution || existingSolution.CompedencyID != updatedSolution.CompedencyID)
                        {
                            // Update the existing solution
                            existingSolution.Solution = updatedSolution.Solution;
                            existingSolution.CompedencyID = updatedSolution.CompedencyID;
                        }
                    }

                }
                // Save changes to the database
                _context.SaveChanges();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
