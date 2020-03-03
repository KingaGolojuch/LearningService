using LearningService.WebApplication.Models.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningService.WebApplication.Models.Course
{
    public class CourseOverwiewViewModel
    {
        public CourseViewModel Course { get; set; }
        public List<LessonBaseViewModel> Lessons { get; set; }
        public int CountSubscribers { get; set; }
    }
}