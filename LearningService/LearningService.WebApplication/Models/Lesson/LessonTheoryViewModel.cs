using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningService.WebApplication.Models.Lesson
{
    public class LessonTheoryViewModel : LessonBaseViewModel
    {
        [Display(Name = "Treść")]
        [Required]
        [AllowHtml]
        public string LessonContent { get; set; }

        public LessonCourseContainerViewModel LessonContainerBase { get; set; }
    }
}