using System;

namespace LearningService.DAO.Entities
{
    public class ActivityLog
    {
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Description { get; set; }
        public virtual User User { get; set; }
        public virtual ActivityType ActivityType { get; set; }
    }
}
