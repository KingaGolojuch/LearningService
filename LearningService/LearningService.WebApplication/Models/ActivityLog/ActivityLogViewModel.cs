using LearningService.WebApplication.Helpers.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace LearningService.WebApplication.Models.ActivityLog
{
    public class ActivityLogViewModel
    {
        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        public string GetDate()
        {
            return Date.ToFullDateWithoutSeconds();
        }
    }
}