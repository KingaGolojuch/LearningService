using FluentNHibernate.Mapping;
using LearningService.DAO.Entities;

namespace LearningService.DAO.Mappings
{
    public class LessonComponentMap : ClassMap<LessonComponent>
    {
        public LessonComponentMap()
        {
            Table("LessonComponent");

            Id(x => x.Id);
            Map(x => x.Name, "Name").Not.Nullable();

            References(x => x.Lesson, "LessonId").Cascade.None();
        }
    }
}
