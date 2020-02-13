using FluentNHibernate.Mapping;
using LearningService.DAO.Entities;

namespace LearningService.DAO.Mappings
{
    public class ArticleMap : ClassMap<Article>
    {
        public ArticleMap()
        {
            Table("Article");

            Id(x => x.Id);
            Map(x => x.Headline, "Headline").Not.Nullable();
            Map(x => x.ContentArticle, "ContentOfArticle").Not.Nullable();
            Map(x => x.Active, "Active").Not.Nullable();
            Map(x => x.CreateTime, "CreateTime").Not.Nullable();
            Map(x => x.UpdateTime, "UpdateTime").Not.Nullable();

            References(x => x.User, "UserId").Cascade.None();
        }
    }
}
