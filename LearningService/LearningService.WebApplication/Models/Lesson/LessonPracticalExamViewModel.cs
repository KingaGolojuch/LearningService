using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningService.WebApplication.Models.Lesson
{
    public class LessonPracticalExamViewModel : LessonBaseViewModel
    {
        [Display(Name = "Treść")]
        [Required]
        public string LessonContent { get; set; }

        
    }
}
