using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.DAO.Entities
{
    public class Lesson
    {
        public virtual int Id { get; set; }
        public virtual int CourseId { get; set; }
        public virtual int LessonTypeId { get; set; }
        public virtual int Order { get; set; }

        public virtual Course Course { get; set; }
        public virtual LessonType LessonType { get; set; }
    }
}