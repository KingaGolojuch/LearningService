using FluentNHibernate.Mapping;
using LearningService.DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.DAO.Mappings
{
    public class LessonTypeMap : ClassMap<LessonType>
    {
        public LessonTypeMap()
        {
            Table("LessonType");

            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Name, "Name");
        }
    }
}