using LearningService.Helpers;
using System.Collections.Generic;

namespace LearningService.DAO.Entities
{
    public class Course
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual IEnumerable<Lesson> Lessons { get; set; }
    }
}