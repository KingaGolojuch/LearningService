using AutoMapper;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using LearningService.WebApplication.Helpers;
using LearningService.WebApplication.Models;
using LearningService.WebApplication.Models.ActivityLog;
using LearningService.WebApplication.Models.Article;
using LearningService.WebApplication.Models.Course;
using LearningService.WebApplication.Models.Lesson;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LearningService.WebApplication.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICourseService _courseService;
        private readonly IArticleService _articleService;
        private readonly IActivityLogService _activityLogService;

        public HomeController(
            ICourseService courseService,
            IArticleService articleService,
            IActivityLogService activityLogService)
        {
            _courseService = courseService;
            _articleService = articleService;
            _activityLogService = activityLogService;
        }

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View("StartPageUnloggeUser");

            var userId = GetUserId;
            var activites = _activityLogService.GetLogs(userId);
            var model = new HomePageViewModel
            {
                Articles = Mapper.Map<IEnumerable<ArticleBaseViewModel>>(_articleService.Get(userId).Where(x => x.Active == true).OrderByDescending(x => x.CreateTime).Take(3)),
                Courses = Mapper.Map<IEnumerable<CourseViewModel>>(_courseService.Get(userId).OrderByDescending(x => x.Id).Take(3)),
                ArticleActivities = Mapper.Map<IEnumerable<ActivityLogViewModel>>(activites.Take(3)),
                CourseActivities = Mapper.Map<IEnumerable<ActivityLogViewModel>>(activites.Take(3))
            };
            return View(model);
        }
    }
}