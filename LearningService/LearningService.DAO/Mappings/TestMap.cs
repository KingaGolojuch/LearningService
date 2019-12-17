using FluentNHibernate.Mapping;
using LearningService.DAO.Entities;

namespace LearningService.DAO.Mappings
{
    public class TestMap : ClassMap<TestEntity>
    {
        public TestMap()
        {
            Table("Test");

            Id(x => x.Id);
            Map(x => x.Name, "Name").Not.Nullable();
            Map(x => x.Accepted, "Accepted").Not.Nullable();
        }
    }
}