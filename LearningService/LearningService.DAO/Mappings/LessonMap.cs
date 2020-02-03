using FluentNHibernate.Mapping;
using LearningService.DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.DAO.Mappings
{
    public class LessonMap : ClassMap<Lesson>
    {
        public LessonMap()
        {
            Table("Lesson");

            Id(x => x.Id);
            Map(x => x.OrderLesson, "OrderLesson");

            References(x => x.Course, "CourseId").Cascade.None();
            References(x => x.LessonType, "LessonTypeId").Cascade.None();
        }
    }
}