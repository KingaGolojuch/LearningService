using System;

namespace LearningService.DAO.Entities
{
    public class ActivityLog
    {
        public virtual int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public virtual User User { get; set; }
        public virtual ActivityType ActivityType { get; set; }
    }
}
