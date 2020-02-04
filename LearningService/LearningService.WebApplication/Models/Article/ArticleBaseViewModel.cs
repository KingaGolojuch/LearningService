using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        public string ContentArticle { get; set; }
    }
}