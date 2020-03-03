using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningService.WebApplication.Models.Course
{
    public class CourseMailViewModel
    {
        public int CourseId { get; set; }

        [Display(Name = "Treść")]
        [AllowHtml]
        [Required]
        public string MailContent { get; set; }
    }
}