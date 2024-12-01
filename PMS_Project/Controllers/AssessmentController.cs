using DL_PMS.Abstract;
using DL_PMS.Model;
using DL_PMS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PMS_Project.Controllers
{
    public class AssessmentController : Controller
    {
        IAssessmentRepository obj = new AssessmentRepository();
        PMS_Context _Context = new PMS_Context();
        [Authorize]
        public IActionResult AllAssess()
        {
            List<Assessment> list = obj.GetAllAssessmentList();
            return View(list);
        }
        [HttpGet]
        [Authorize]
        public IActionResult NewAssess()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult NewAssess(AssessmentVM assvm)
        {
            string msg = obj.AddAssesssment(assvm);
            if (msg == "Success")
            {
                return RedirectToAction("AllAssess");
            }
            return View(assvm);
        }
        [Authorize]
        public IActionResult CStudy()
        {
            List<CaseStudyDetails> lst = obj.AllCase();
            return View(lst);
        }
        [Authorize]
        public IActionResult CSSolution()
        {
            List<CaseStudySolutions> lst = obj.AllSolutions();
            return View(lst);
        }
        [Authorize]
        [HttpGet]
        public IActionResult CreateContent()
        {
            var crtcnrVM = new CreateContentVM();
            var Assment = obj.GetAllAssessmentList();

            ViewBag.Assment = Assment.Select(r => new SelectListItem
            {
                Value = r.AssId.ToString(),
                Text = r.AssessmentName
            }).ToList();

            var competency = obj.GetCompetency();

            ViewBag.Comp = competency.Select(r => new SelectListItem
            {
                Value = r.CompId.ToString(),
                Text = r.CompName
            }).ToList();

            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateContent(CreateContentVM crtcntVm)
        {
            string msg = obj.CreateContent(crtcntVm);
            if (msg == "Success")
            {
                return RedirectToAction("CStudy");
            }
            return View(crtcntVm);
        }
    }
}
