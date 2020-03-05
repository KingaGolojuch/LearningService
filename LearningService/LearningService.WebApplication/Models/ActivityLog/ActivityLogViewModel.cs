using LearningService.WebApplication.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningService.WebApplication.Models.ActivityLog
{
    public class ActivityLogViewModel
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public string GetDate()
        {
            return Date.ToFullDateWithoutSeconds();
        }
    }
}