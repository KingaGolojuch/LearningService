using LearningService.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace LearningService.DAO.Entities
{
    public class Course
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual IEnumerable<Lesson> Lessons { get; set; }

        public virtual int GetNextOrderLesson()
        {
            if (Lessons == null || !Lessons.Any())
                return 1;

            var countOfLessons = Lessons.Count();
            return countOfLessons + 1;
        }
    }
}