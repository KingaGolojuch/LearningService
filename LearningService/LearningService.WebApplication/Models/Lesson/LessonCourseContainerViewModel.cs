﻿using LearningService.WebApplication.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningService.WebApplication.Models.Lesson
{
    public class LessonCourseContainerViewModel
    {
        public int CourseId { get; set; }
        public IEnumerable<LessonBaseViewModel> Lessons { get; set; }
        public int CountSubscribers { get; set; }
    }
}