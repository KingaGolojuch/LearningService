using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningService.WebApplication.Models.User
{
    public class UserManageViewModel
    {
        public UserViewModel User { get; set; }
        public int ArticleCount { get; set; }
        public int CourseCount { get; set; }
    }
}