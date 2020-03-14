using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningService.WebApplication.Models.Lesson
{
    public class LessonBaseSubscriberViewModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CountSubscribers { get; set; }
    }
}