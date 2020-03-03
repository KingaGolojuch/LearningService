using AutoMapper;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using LearningService.WebApplication.Helpers;
using LearningService.WebApplication.Models.Course;
using LearningService.WebApplication.Models.Lesson;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LearningService.WebApplication.Controllers
{
    [Authorize]
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;
        private readonly ILessonService _lessonService;
        private readonly IUserService _userService;
        private ApplicationUserManager _userManager;

        public CourseController(
            ICourseService courseService,
            ILessonService lessonService,
            IUserService userService,
            ApplicationUserManager userManager)
        {
            _courseService = courseService;
            _lessonService = lessonService;
            _userService = userService;
            _userManager = userManager;
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
            string userId = GetUserId;
            var course = _courseService.Get(courseId, userId);
            var lessonsCourse = _lessonService.GetLessons(courseId, userId);
            var model = new CourseOverwiewViewModel
            {
                Course = Mapper.Map<CourseViewModel>(course),
                Lessons = Mapper.Map<List<LessonBaseViewModel>>(lessonsCourse.OrderBy(x => x.OrderLesson)),
                CountSubscribers = course.UsersSubscribers.Count()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSubscribe(int courseId)
        {
            _userService.AddCourseSubscription(GetUserId, courseId);
            return RedirectToAction("CourseOverwiew", new { courseId });
        }

        public ActionResult AskQuestion(int courseId)
        {
            var model = new CourseMailViewModel
            {
                CourseId = courseId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AskQuestion(CourseMailViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var course = _courseService.Get(model.CourseId);
            var courseOwenr = _userManager.GetEmail(course.UserId);
            var userLoggedIn = _userManager.GetEmail(GetUserId);
            var mailContent = $"Użytkownik o mailu {userLoggedIn} zadał ci pytanie: {model.MailContent}";
            await MailNotification.SendEmail(courseOwenr, $"Otrzymałeś wiadomość do kursu: {course.Name}", mailContent);
            return RedirectToAction("CourseOverwiew", new { model.CourseId });
        }
    }
}