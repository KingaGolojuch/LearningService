using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningService.WebApplication.Models.Lesson
{
    public class LessonTheoryExamLearningViewModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }

        [Display(Name = "Nagłówek")]
        public string Headline { get; set; }

        [Display(Name = "Treść zadania")]
        public string LessonContent { get; set; }

        [Display(Name = "Opcja")]
        [Required(ErrorMessage = "Odpowiedź jest wymagana")]
        public int? SelectedOption { get; set; }

        public List<SelectListItem> Options { get; set; }

        public string Answer { get; set; }
    }
}