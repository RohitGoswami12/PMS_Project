using DL_PMS.Abstract;
using DL_PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_PMS.Repository
{
    public class AssessmentRepository : IAssessmentRepository
    {
        PMS_Context _context = new PMS_Context();
        public List<Assessment> GetAllAssessmentList()
        {
            List<Assessment> list = new List<Assessment>();
            list = _context.AssessmentDetails.ToList();
            return list;
        }

        public string AddAssesssment(AssessmentVM asment)
        {
            string msg = "";
            if (asment.Active == true)
            {
                var activeAssessment = _context.AssessmentDetails.Where(a => a.Active == true).ToList();
                foreach (var a in activeAssessment)
                {
                    a.Active = false;
                }
            }
            // Create a new assessment record
            var assessment = new Assessment
            {
                AssessmentName = asment.AssessmentName,
                Date = asment.Date,
                Description = asment.Description,
                Active = asment.Active
            };
            try
            {
                _context.AssessmentDetails.Add(assessment);
                _context.SaveChanges();
                msg = "Success";
            }
            catch (Exception ex)
            {
                {
                    msg = ex.Message;
                }

            }
            return msg;

        }
        public List<CaseStudyDetails> AllCase()
        {
            List<CaseStudyDetails> lst = new List<CaseStudyDetails>();
            try
            {
                lst = _context.CaseStudyDetails.ToList();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return lst;
        }
        public List<CaseStudySolutions> AllSolutions()
        {
            List<CaseStudySolutions> lst = new List<CaseStudySolutions>();
            try
            {
                lst = _context.CaseStudySolutions.ToList();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return lst;
        }

        public List<CompetencyDetails> GetCompetency()
        {
            List<CompetencyDetails> competencyDetails = new List<CompetencyDetails>();
            try
            {
                competencyDetails = _context.CompetencyDetails.ToList();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return competencyDetails;
        }
        public string CreateContent(CreateContentVM content)
        {
            string msg = "";

            try
            {
                var caseStudy = new CaseStudyDetails
                {
                    CaseStudy = content.Casestudy,
                    AssessmentId = content.AssessmentId,
                    ReviewStatus = true,
                    CreatedBy = "",

                };
                _context.CaseStudyDetails.Add(caseStudy);
                _context.SaveChanges();

                var solutions = new List<CaseStudySolutions>()
                {
                    new CaseStudySolutions {Solution = content.Sol1, CompedencyID = content.CompId1, CSID = caseStudy.CsSID },
                    new CaseStudySolutions {Solution = content.Sol2, CompedencyID = content.CompId2, CSID = caseStudy.CsSID },
                    new CaseStudySolutions {Solution = content.Sol3, CompedencyID = content.CompId3, CSID = caseStudy.CsSID },
                    new CaseStudySolutions {Solution = content.Sol4, CompedencyID = content.CompId4, CSID = caseStudy.CsSID }
                };

                _context.CaseStudySolutions.AddRange(solutions);
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
