﻿using FluentNHibernate.Mapping;
using LearningService.DAO.Entities;

namespace LearningService.DAO.Mappings
{
    public class CourseMap : ClassMap<Course>
    {
        public CourseMap()
        {
            Table("Course");

            Id(x => x.Id);
            Map(x => x.Name, "Name").Not.Nullable();
            
            References(x => x.User, "ApplicationUserId").ReadOnly().Cascade.None();
            HasMany(x => x.Lessons)
                  .KeyColumn("CourseId")
                  .Inverse()
                  .Cascade.AllDeleteOrphan();
        }
    }
}