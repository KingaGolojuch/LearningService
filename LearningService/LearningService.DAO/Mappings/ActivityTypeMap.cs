using FluentNHibernate.Mapping;
using LearningService.DAO.CustomTypes;
using LearningService.DAO.Entities;

namespace LearningService.DAO.Mappings
{
    public class ActivityTypeMap : ClassMap<ActivityType>
    {
        public ActivityTypeMap()
        {
            Table("ActivityType");
            ReadOnly();

            Id(x => x.Id).CustomType(typeof (ActivityTypeCustom));
            Map(x => x.Name, "Name").Not.Nullable();

            HasMany(x => x.Activities)
                  .KeyColumn("ActivityTypeId")
                  .Inverse()
                  .Cascade.AllDeleteOrphan();
        }
    }
}
