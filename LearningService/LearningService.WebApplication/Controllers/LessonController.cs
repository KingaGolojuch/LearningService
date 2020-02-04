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
    public class LessonController : BaseController
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        // GET: Lesson
        public ActionResult Index(int courseId)
        {
            var allLessons = _lessonService.GetLessons(courseId);
            var model = Mapper.Map<IEnumerable<LessonBaseViewModel>>(allLessons);
            return View(model);
        }
    }
}