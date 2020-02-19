using FluentNHibernate.Mapping;
using LearningService.DAO.Entities;
namespace LearningService.DAO.Mappings
{
    public class UserLessonMap : ClassMap<UserLesson>
    {
        public UserLessonMap()
        {
            Table("UserLesson");

            Id(x => x.Id);

            References(x => x.User)
                .Not.Nullable()
                .Cascade.None()
                .Column("UserId");

            References(x => x.Lesson)
                .Not.Nullable()
                .Cascade.None()
                .Column("LessonId");
        }
    }
}
