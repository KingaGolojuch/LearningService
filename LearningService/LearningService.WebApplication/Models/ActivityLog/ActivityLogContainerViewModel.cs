using System.Collections.Generic;

namespace LearningService.WebApplication.Models.ActivityLog
{
    public class ActivityLogContainerViewModel
    {
        public IEnumerable<ActivityLogViewModel> UserActivities { get; set; }
    }
}