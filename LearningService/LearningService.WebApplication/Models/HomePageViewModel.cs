using LearningService.WebApplication.Models.ActivityLog;
using LearningService.WebApplication.Models.Article;
using LearningService.WebApplication.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningService.WebApplication.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<ArticleBaseViewModel> Articles { get; set; }
        public IEnumerable<CourseViewModel> Courses { get; set; }
        public IEnumerable<ActivityLogViewModel> ArticleActivities { get; set; }
        public IEnumerable<ActivityLogViewModel> CourseActivities { get; set; }
    }
}