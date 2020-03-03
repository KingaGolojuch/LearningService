using FluentNHibernate.Mapping;
using LearningService.DAO.Entities;

namespace LearningService.DAO.Mappings
{
    public class ActivityLogMap : ClassMap<ActivityLog>
    {
        public ActivityLogMap()
        {
            Table("ActivityLog");

            Id(x => x.Id);
            Map(x => x.Date, "CreateTime").Not.Nullable();
            Map(x => x.Description, "ActivityDescription").Not.Nullable().Length(4001);

            References(x => x.User, "UserId").Cascade.None();
            References(x => x.ActivityType, "ActivityTypeId").Cascade.None();
        }
    }
}
