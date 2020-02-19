using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.DAO.Entities
{
    public class User
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual bool Active { get; set; }

        public virtual IList<UserCourseSubscription> UserCourseSubscription { get; set; }
        public virtual IList<UserLesson> UserLessons { get; set; }

        public virtual void AddCourse(UserCourseSubscription course)
        {
            UserCourseSubscription.Add(course);
        }
    }
}
