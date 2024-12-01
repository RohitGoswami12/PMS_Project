using DL_PMS.Abstract;
using DL_PMS.Model;
using DL_PMS.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_PMS
{
    public class BLPMSAssessment
    {
        IAssessmentRepository _repo = new AssessmentRepository();
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
            lst = _repo.AllCase();
            return lst;
        }
        public List<CaseStudySolutions> AllSolutions()
        {
            List<CaseStudySolutions> lst = new List<CaseStudySolutions>();
            lst = _repo.AllSolutions();
            return lst;
        }
        public List<CompetencyDetails> GetAllCompetency()
        {
            List<CompetencyDetails> competencyDetails = new List<CompetencyDetails>();
            competencyDetails = _repo.GetCompetency();
            return competencyDetails;
        }
        public String CreateContent(CreateContentVM CrtCnt)
        {
            string msg = _repo.CreateContent(CrtCnt);
            if (msg == "Success")
            {
                return "Success";
            }
            return "Failed";
        }
    }
}
