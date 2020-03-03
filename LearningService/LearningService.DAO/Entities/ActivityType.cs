using LearningService.DAO.CustomTypes;
using System.Collections.Generic;

namespace LearningService.DAO.Entities
{
    public class ActivityType
    {
        public virtual ActivityTypeCustom Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IEnumerable<ActivityLog> Activities { get; set; }
    }
}
