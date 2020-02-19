using AutoMapper;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using LearningService.WebApplication.Models.Course;
using LearningService.WebApplication.Models.Lesson;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LearningService.WebApplication.Controllers
{
    [Authorize]
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;
        private readonly ILessonService _lessonService;
        private readonly IUserService _userService;

        public CourseController(
            ICourseService courseService,
            ILessonService lessonService,
            IUserService userService)
        {
            _courseService = courseService;
            _lessonService = lessonService;
            _userService = userService;
        }
        // GET: Test
        public ActionResult Index()
        {
            var courses = _courseService.Get(GetUserId);
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

            var courseDTO = Mapper.Map<CourseDTO>(model);
            courseDTO.UserId = GetUserId;
            _courseService.Add(courseDTO);
            return RedirectToAction("Index");
        }
        
        public ActionResult UserCourses()
        {
            var courses = _courseService.GetFromOtherUsers(GetUserId);
            var model = Mapper.Map<IEnumerable<CourseViewModel>>(courses);
            return View(model);
        }

        public ActionResult CourseOverwiew(int courseId)
        {
            var course = _courseService.Get(courseId, GetUserId);
            var lessonsCourse = _lessonService.GetLessons(courseId);
            var model = new CourseOverwiewViewModel
            {
                Course = Mapper.Map<CourseViewModel>(course),
                Lessons = Mapper.Map<List<LessonBaseViewModel>>(lessonsCourse)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSubscribe(int courseId)
        {
            _userService.AddCourseSubscription(GetUserId, courseId);
            return RedirectToAction("CourseOverwiew", new { courseId });
        }
    }
}