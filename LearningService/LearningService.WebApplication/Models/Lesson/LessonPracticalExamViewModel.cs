using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LearningService.WebApplication.Models.Lesson
{
    public class LessonPracticalExamViewModel : LessonBaseViewModel, IValidatableObject
    {
        [Display(Name = "Treść")]
        [Required]
        [AllowHtml]
        public string LessonContent { get; set; }

        [Display(Name = "Typ zwracany")]
        [Required]
        public string SelectedOption { get; set; }

        public List<SelectListItem> ReturnTypeOptions { get; set; }

        [Display(Name = "Wynik")]
        public string Answer { get; set; }

        public List<string> RequiredNames { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            Validator.TryValidateProperty(this.Headline,
                    new ValidationContext(this, null, null) { MemberName = "Headline" },
                    results);

            Validator.TryValidateProperty(this.LessonContent,
                    new ValidationContext(this, null, null) { MemberName = "LessonContent" },
                    results);
            
            if (SelectedOption != "void")
            {
                Validator.TryValidateProperty(this.Answer,
                    new ValidationContext(this, null, null) { MemberName = "Answer" },
                    results);
            }

            return results;
        }
    }
}
