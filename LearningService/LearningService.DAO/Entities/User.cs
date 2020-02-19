using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.DAO.Entities
{
    public class User
    {
        public virtual bool DataChanged { get; protected set; } = false;

        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual bool Active { get; set; }

        public virtual IList<UserCourseSubscription> UserCourseSubscription { get; set; }
        public virtual IList<UserLesson> UserLessons { get; set; }

        public virtual void AddCourse(UserCourseSubscription userCourse)
        {
            if (UserCourseSubscription.Select(x => x.Course.Id).Contains(userCourse.Course.Id))
                return;

            UserCourseSubscription.Add(userCourse);
            DataChanged = true;
        }

        public virtual void AddLesson(UserLesson userLesson)
        {
            if (UserLessons.Select(x => x.Lesson.Id).Contains(userLesson.Lesson.Id))
                return;
            
            UserLessons.Add(userLesson);
            DataChanged = true;
        }
    }
}
