using System.Collections.Generic;
using System.Linq;

namespace LearningService.DAO.Entities
{
    public class Course
    {
        public virtual bool DataChanged { get; protected set; } = false;

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        //User that create course
        public virtual ApplicationUser User { get; set; }
        public virtual IEnumerable<Lesson> Lessons { get; set; }
        //users thats subscribe course
        public virtual IList<UserCourseSubscription> UserCourseSubscription { get; set; }

        public virtual int GetNextOrderLesson()
        {
            if (Lessons == null || !Lessons.Any())
                return 1;

            var countOfLessons = Lessons.Count();
            return countOfLessons + 1;
        }
        
        public virtual void ChangeOrderLessonUp(Lesson lesson)
        {
            var targetOrder = lesson.OrderLesson;
            var lessonToSwap = Lessons.SingleOrDefault(x => x.OrderLesson == targetOrder - 1);
            if (lessonToSwap == null)
                return;

            lessonToSwap.OrderLesson = targetOrder;
            lesson.OrderLesson = lesson.OrderLesson - 1;
            DataChanged = true;
        }

        public virtual void ChangeOrderLessonDown(Lesson lesson)
        {
            var targetOrder = lesson.OrderLesson;
            var lessonToSwap = Lessons.SingleOrDefault(x => x.OrderLesson == targetOrder + 1);
            if (lessonToSwap == null)
                return;

            lessonToSwap.OrderLesson = targetOrder;
            lesson.OrderLesson = lesson.OrderLesson + 1;
            DataChanged = true;
        }
    }
}