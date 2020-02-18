using FluentNHibernate.Mapping;
using LearningService.DAO.Entities;

namespace LearningService.DAO.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("ApplicationUser");
            
            Id(x => x.Id, "applicationuser_key");
            Map(x => x.Name, "Name").Nullable();
            Map(x => x.Surname, "Surname").Nullable();
            Map(x => x.Active, "Active").Nullable();
            HasMany(x => x.UserCourseSubscription)
                 .Cascade.AllDeleteOrphan()
                 .Inverse()
                 .KeyColumn("UserId");

            //HasManyToMany(x => x.Courses)
            //   .Table("UserCourseSubscription")
            //   .ParentKeyColumns.Add("UserId")
            //   .ChildKeyColumns.Add("CourseId")
            //   .Inverse()
            //   .Cascade.All();

            //HasManyToMany(x => x.Courses)
            //   .Cascade.All()
            //   .Table("UserCourseSubscription");
        }
    }
}
