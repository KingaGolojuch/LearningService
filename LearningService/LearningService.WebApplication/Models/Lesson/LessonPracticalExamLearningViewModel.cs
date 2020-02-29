using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LearningService.WebApplication.Models.Lesson
{
    public class LessonPracticalExamLearningViewModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }

        [Display(Name = "Nagłówek")]
        public string Headline { get; set; }

        [Display(Name = "Treść zadania")]
        public string LessonContent { get; set; }

        [Display(Name = "Kod")]
        [Required]
        [AllowHtml]
        public string Code { get; set; }
    }
}
