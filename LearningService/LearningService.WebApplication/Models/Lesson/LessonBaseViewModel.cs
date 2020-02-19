using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningService.WebApplication.Models.Lesson
{
    public class LessonBaseViewModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }

        [Display(Name = "Nagłówek")]
        [Required]
        public string Headline { get; set; }

        public bool AlreadyPassed { get; set; }
    }
}