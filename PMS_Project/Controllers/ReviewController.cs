using BL_PMS;
using DL_PMS.Abstract;
using DL_PMS.Model;
using DL_PMS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PMS_Project.Controllers
{
    public class ReviewController : Controller
    {
        BLPMSReviewContent obj = new BLPMSReviewContent();
        PMS_Context _context = new PMS_Context();
        [HttpGet]
        // GET: ContentReview
        public IActionResult Review()
        {

            var assessments = obj.GetallUAssessment(); // Retrieve assessments

            var model = new ContentReviewVM
            {
                Assessments = assessments.ToList() // Pass the list of assessments directly
            };

            return View(model);

        }
        [HttpPost]
        public JsonResult GetCaseStudiesByAssessment(int assessmentId)
        {
            var caseStudies = obj.GetallCasestudyDetail(assessmentId).ToList();
            var result = caseStudies.Select(cs => new
            {
                csId = cs.CaseStudyId,
                csName = cs.CaseStudy // Ensure these property names are consistent
            }).ToList();
            return Json(result);
        }

        public IActionResult Edit(int id)
        {
            List<CaseStudySolutions> solution = new List<CaseStudySolutions>();
            CaseStudyDetails caseStudyDetail = new CaseStudyDetails();
            CompetencyDetails competency = new CompetencyDetails();
            caseStudyDetail = obj.GetCaseStudyById(id);
            solution = obj.GetallSolutions(id).ToList();
            if (solution == null)
            {
                return NotFound();
            }

            // Prepare the CreateContentVM with the existing data
            var viewModel = new ContentEditVM
            {
                CaseStudy = caseStudyDetail.CaseStudy,
                CaseStudyId = caseStudyDetail.CsSID,
                AssID = caseStudyDetail.AssessmentId,
                Sol1 = solution.ElementAtOrDefault(0)?.Solution,
                Sol2 = solution.ElementAtOrDefault(1)?.Solution,
                Sol3 = solution.ElementAtOrDefault(2)?.Solution,
                Sol4 = solution.ElementAtOrDefault(3)?.Solution,
                CompId1 = solution.ElementAtOrDefault(0)?.CompedencyID ?? 0,
                CompId2 = solution.ElementAtOrDefault(1)?.CompedencyID ?? 0,
                CompId3 = solution.ElementAtOrDefault(2)?.CompedencyID ?? 0,
                CompId4 = solution.ElementAtOrDefault(3)?.CompedencyID ?? 0,
                // Competencies = competencies.ToList() // Pass the list of competencies directly
            };
            var comptency = obj.GetAllCompetency();

            ViewBag.Comp = comptency.Select(c => new SelectListItem
            {
                Value = c.CompId.ToString(),
                Text = c.CompName
            }).ToList();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(ContentEditVM viewModel)
        {
            var msg = obj.EditCaseStudySolu(viewModel);
            if (msg == "Success")
            {
                return RedirectToAction("Review");
            }
            return View(viewModel);
        }
    }
}
