using AutoMapper;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using LearningService.WebApplication.Models.Course;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LearningService.WebApplication.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService testService)
        {
            this._courseService = testService;
        }
        // GET: Test
        public ActionResult Index()
        {
            var courses = _courseService.Get();
            var model = Mapper.Map<IEnumerable<CourseViewModel>>(courses);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _courseService.Add(Mapper.Map<CourseDTO>(model));
            return RedirectToAction("Index");
        }
    }
}