using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LearningService.WebApplication.Models.Lesson
{
    public class LessonPracticalExamViewModel : LessonBaseViewModel
    {
        [Display(Name = "Treść")]
        [Required]
        public string LessonContent { get; set; }

        [Display(Name = "Typ zwracany")]
        [Required]
        public string SelectedOption { get; set; }

        public List<SelectListItem> ReturnTypeOptions { get; set; }

        [Display(Name = "Wynik")]
        public string Answer { get; set; }

        public List<string> RequiredNames { get; set; }
    }
}
