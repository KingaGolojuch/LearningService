using System.ComponentModel.DataAnnotations;

namespace LearningService.WebApplication.Models.Article
{
    public class ArticleBaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nagłówek")]
        [Required]
        public string Headline { get; set; }

        [Display(Name = "Zawartość")]
        [Required]
        [System.Web.Mvc.AllowHtml]
        public string ContentArticle { get; set; }

        [Display(Name = "Skrócony opis")]
        [Required]
        public string ContentShortened { get; set; }

        [Display(Name = "Data utworzenia")]
        public string CreateTime { get; set; }

        [Display(Name = "Data edycji")]
        public string UpdateTime { get; set; }
    }
}
