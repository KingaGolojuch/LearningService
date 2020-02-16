using AutoMapper;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using LearningService.WebApplication.Models.Course;
using LearningService.WebApplication.Models.Lesson;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LearningService.WebApplication.Controllers
{
    public class LessonController : BaseController
    {
        private readonly ICourseService _courseService;
        private readonly ILessonService _lessonService;

        public LessonController(
            ICourseService courseService,
            ILessonService lessonService)
        {
            _courseService = courseService;
            _lessonService = lessonService;
        }
        // GET: Lesson
        public ActionResult Index(int courseId)
        {
            var course = _courseService.Get(courseId);
            var allLessons = _lessonService.GetLessons(courseId);
            var model = new LessonCourseContainerViewModel
            {
                Course = Mapper.Map<CourseViewModel>(course),
                Lessons = Mapper.Map<IEnumerable<LessonBaseViewModel>>(allLessons)
            };
            return View(model);
        }

        public ActionResult CreateTheory(int courseId)
        {
            var model = new LessonTheoryViewModel{
                CourseId = courseId
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateTheory(LessonTheoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var lessonDTO = Mapper.Map<LessonDTO>(model);
            _lessonService.AddLessonTheory(lessonDTO);
            return RedirectToAction("Index", new { courseId = model.CourseId });
        }

        public ActionResult EditTheory(int lessonId)
        {
            var lessonDTO = _lessonService.GetLesson(lessonId);
            if (lessonDTO == null)
                return RedirectToAction("Index", "Course");

            var model = Mapper.Map<LessonTheoryViewModel>(lessonDTO);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditTheory(LessonTheoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var lessonDTO = Mapper.Map<LessonDTO>(model);
            _lessonService.EditLessonTheory(lessonDTO);
            return RedirectToAction("Index", new { courseId = model.CourseId });
        }
        
        public ActionResult CreateTheoryExam(int courseId)
        {
            var model = new LessonTheoryExamViewModel
            {
                CourseId = courseId,
                Options = new List<LessonTheoryOptionViewModel>()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateTheoryExam(LessonTheoryExamViewModel model)
        {
            if (model.Options == null || !model.Options.Any())
            {
                ModelState.AddModelError(string.Empty, "Brak opcji. Dodaj aby zapisać");
                model.Options = new List<LessonTheoryOptionViewModel>();
                return View(model);
            }

            if (model.Options.Count() == 1)
            {
                ModelState.AddModelError(string.Empty, "Musi być więcej jak jedna opcja. Tylko jedna odpowiedź może być prawidłowa");
                return View(model);
            }

            if (model.Options.Where(x => x.Selected == true).Count() != 1)
            {
                ModelState.AddModelError(string.Empty, "Tylko jedna odpowiedź może być prawidłowa");
                return View(model);
            }

            if (!ModelState.IsValid)
                return View(model);

            var lessonDTO = Mapper.Map<LessonDTO>(model);
            _lessonService.AddLessonTheory(lessonDTO);
            return RedirectToAction("Index", new { courseId = model.CourseId });
        }
    }
}