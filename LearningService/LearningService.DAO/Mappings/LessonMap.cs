using FluentNHibernate.Mapping;
using LearningService.DAO.Entities;

namespace LearningService.DAO.Mappings
{
    public class LessonMap : ClassMap<Lesson>
    {
        public LessonMap()
        {
            Table("Lesson");

            Id(x => x.Id);
            Map(x => x.OrderLesson, "OrderLesson");
            Map(x => x.Headline, "Headline");
            Map(x => x.LessonContent, "LessonContent");

            References(x => x.Course, "CourseId").Cascade.None();
            References(x => x.LessonType, "LessonTypeId").Cascade.None();
        }
    }
}
