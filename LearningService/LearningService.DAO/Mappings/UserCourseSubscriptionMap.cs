using FluentNHibernate.Mapping;
using LearningService.DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.DAO.Mappings
{
    public class UserCourseSubscriptionMap : ClassMap<UserCourseSubscription>
    {
        public UserCourseSubscriptionMap()
        {
            Table("UserCourseSubscription");

            Id(x => x.Id);

            References(x => x.User)
                .Not.Nullable()
                .Cascade.None()
                .Column("UserId");

            References(x => x.Course)
                .Not.Nullable()
                .Cascade.None()
                .Column("CourseId");
        }
    }
}
