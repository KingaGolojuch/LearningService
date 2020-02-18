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
            Map(x => x.Description, "Description").Not.Nullable();

            References(x => x.User, "UserId").Cascade.None();
            HasMany(x => x.Lessons)
                  .KeyColumn("CourseId")
                  .Inverse()
                  .Cascade.AllDeleteOrphan();
        }
    }
}