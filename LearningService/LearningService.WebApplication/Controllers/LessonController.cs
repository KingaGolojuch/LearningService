using AutoMapper;
using LearningService.Domain.Enums;
using LearningService.Domain.Exceptions;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using LearningService.WebApplication.Helpers;
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
        private readonly IUserService _userService;

        public LessonController(
            ICourseService courseService,
            ILessonService lessonService,
            IUserService userService)
        {
            _courseService = courseService;
            _lessonService = lessonService;
            _userService = userService;
        }
        // GET: Lesson
        public ActionResult Index(int courseId)
        {
            var course = _courseService.Get(courseId);
            var allLessons = _lessonService.GetLessons(courseId);
            var model = new LessonCourseContainerViewModel
            {
                Course = Mapper.Map<CourseViewModel>(course),
                Lessons = Mapper.Map<IEnumerable<LessonBaseViewModel>>(allLessons.OrderBy(x => x.OrderLesson))
            };
            return View(model);
        }

        public RedirectToRouteResult Edit(int lessonId)
        {
            var lessonDTO = _lessonService.GetLesson(lessonId);
            if (lessonDTO == null)
                return RedirectToAction("Index", "Course");

            if (lessonDTO.LessonType == LessonTypeCustom.Theory)
                return RedirectToAction("EditTheory", new { lessonId = lessonId });

            if (lessonDTO.LessonType == LessonTypeCustom.TheoryExam)
                return RedirectToAction("EditTheoryExam", new { lessonId = lessonId });

            if (lessonDTO.LessonType == LessonTypeCustom.PracticalExam)
                return RedirectToAction("EditPracticalExam", new { lessonId = lessonId });

            return RedirectToAction("Index", "Course");
        }

        public ActionResult ChangeOrder(int lessonId, bool orderDown)
        {
            var orderDirection = orderDown ? LessonOrderChangeDirection.Down : LessonOrderChangeDirection.Up;
            _lessonService.ChangeOrderLesson(lessonId, orderDirection);
            var lesson = _lessonService.GetLesson(lessonId);
            return RedirectToAction("Index", new { courseId = lesson.CourseId });
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
            var answers = Mapper.Map<IEnumerable<LessonComponentDTO>>(model.Options);
            _lessonService.AddTheoryTest(lessonDTO, answers);
            return RedirectToAction("Index", new { courseId = model.CourseId });
        }


        public ActionResult EditTheoryExam(int lessonId)
        {
            var lessonDTO = _lessonService.GetLesson(lessonId);
            if (lessonDTO == null)
                return RedirectToAction("Index", "Course");

            var lessonOptions = _lessonService.GetLessonOptions(lessonId);
            var model = Mapper.Map<LessonTheoryExamViewModel>(lessonDTO);
            model.Options = Mapper.Map<List<LessonTheoryOptionViewModel>>(lessonOptions);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditTheoryExam(LessonTheoryExamViewModel model)
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
            var answers = Mapper.Map<IEnumerable<LessonComponentDTO>>(model.Options);
            _lessonService.EditTheoryTest(lessonDTO, answers);
            return RedirectToAction("Index", new { courseId = model.CourseId });
        }

        public ActionResult CreatePracticalExam(int courseId)
        {
            var model = new LessonPracticalExamViewModel
            {
                CourseId = courseId,
                ReturnTypeOptions = PracticalTestReturnTypeOptions.Get(),
                RequiredNames = new List<string>() 
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult CreatePracticalExam(LessonPracticalExamViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false });

            var lessonDTO = Mapper.Map<LessonDTO>(model);
            _lessonService.AddPracticalTest(lessonDTO, model.RequiredNames);
            return Json(new { success = true });
        }

        public ActionResult EditPracticalExam(int lessonId)
        {
            var lessonDTO = _lessonService.GetLesson(lessonId);
            if (lessonDTO == null)
                return RedirectToAction("Index", "Course");

            var lessonOptions = _lessonService.GetLessonRequiredNames(lessonId);
            var model = Mapper.Map<LessonPracticalExamViewModel>(lessonDTO);
            model.ReturnTypeOptions = PracticalTestReturnTypeOptions.Get();
            model.RequiredNames = lessonOptions.ToList();
            if (model.Answer == null)
                model.SelectedOption = "void";

            else
                model.SelectedOption = "string";

            return View(model);
        }

        [HttpPost]
        public ActionResult EditPracticalExam(LessonPracticalExamViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false });

            var lessonDTO = Mapper.Map<LessonDTO>(model);
            _lessonService.EditPracticalTest(lessonDTO, model.RequiredNames);
            return RedirectToAction("Index", new { courseId = model.CourseId });
        }

        public ActionResult StartLesson(int lessonId)
        {
            var lessonDTO = _lessonService.GetLesson(lessonId);
            if (lessonDTO == null)
                return RedirectToAction("Index", "Home");

            if (lessonDTO.LessonType == LessonTypeCustom.Theory)
                return RedirectToAction("LearningTheory", new { lessonId = lessonId });

            if (lessonDTO.LessonType == LessonTypeCustom.TheoryExam)
                return RedirectToAction("PassingTheoryExam", new { lessonId = lessonId });

            if (lessonDTO.LessonType == LessonTypeCustom.PracticalExam)
                return RedirectToAction("PassingPracticalExam", new { lessonId = lessonId });

            return RedirectToAction("Index", "Course");
        }

        public ActionResult LearningTheory(int lessonId)
        {
            var lessonDTO = _lessonService.GetLesson(lessonId);
            if (lessonDTO == null)
                return RedirectToAction("Index", "Home");
            
            var model = Mapper.Map<LessonTheoryViewModel>(lessonDTO);
            _lessonService.SetLessonTheoryAsPassed(lessonId, GetUserId);
            return View(model);
        }

        public ActionResult PassingTheoryExam(int lessonId)
        {
            var lessonDTO = _lessonService.GetLesson(lessonId, GetUserId);
            if (lessonDTO == null)
                return RedirectToAction("Index", "Home");

            var model = Mapper.Map<LessonTheoryExamLearningViewModel>(lessonDTO);
            if (lessonDTO.AlreadyPassed)
            {
                model.Answer = lessonDTO.ValidAnswer;
                return View("PassingTheoryExamCompleted", model);
            }
            var lessonOptions = _lessonService.GetLessonOptions(lessonId);
            model.Options = Mapper.Map<List<SelectListItem>>(lessonOptions);
            return View(model);
        }

        [HttpPost]
        public ActionResult PassingTheoryExam(LessonTheoryExamLearningViewModel model)
        {
            var lesson = _lessonService.GetLesson(model.Id);
            model.Headline = lesson.Headline;
            model.LessonContent = lesson.LessonContent;
            var lessonOptions = _lessonService.GetLessonOptions(model.Id);
            model.Options = Mapper.Map<List<SelectListItem>>(lessonOptions);
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _lessonService.AttemptPassTheoryTest(model.Id, model.SelectedOption.Value, GetUserId);
                return RedirectToAction("CourseOverwiew", "Course", new { courseId = lesson.CourseId });
            }
            catch (LessonException)
            {
                ModelState.AddModelError(string.Empty, "Niepoprawna odpowiedź");
                return View(model);
            }
        }

        public ActionResult PassingPracticalExam(int lessonId)
        {
            var lessonDTO = _lessonService.GetLesson(lessonId, GetUserId);
            if (lessonDTO == null)
                return RedirectToAction("Index", "Home");

            var model = Mapper.Map<LessonPracticalExamLearningViewModel>(lessonDTO);
            if (lessonDTO.AlreadyPassed)
                return View("PassingPracticalExamCompleted", model);

            return View(model);
        }

        [HttpPost]
        public ActionResult PassingPracticalExam(LessonPracticalExamLearningViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _lessonService.AttemptPassPracticalTest(model.Id, model.Code, GetUserId);

            }
            catch (LessonException ex)
            {
                IEnumerable<string> messages = ex.Message.Split(',');
                foreach (var message in messages)
                {
                    ModelState.AddModelError(string.Empty, message);
                }
                
                return View(model);
            }

            return RedirectToAction("CourseOverwiew", "Course", new { courseId = model.CourseId });
        }
    }
}
