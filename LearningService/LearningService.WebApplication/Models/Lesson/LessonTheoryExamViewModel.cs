using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LearningService.WebApplication.Models.Lesson
{
    public class LessonTheoryExamViewModel : LessonBaseViewModel
    {
        [Display(Name = "Treść")]
        [Required]
        [AllowHtml]
        public string LessonContent { get; set; }
        
        public List<LessonTheoryOptionViewModel> Options { get; set; }
        
        public int CountOfOptions {
            get
            {
                return Options?.Count ?? 0;
            }
        }
    }
}
