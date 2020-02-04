using FluentNHibernate.Mapping;
using LearningService.DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            References(x => x.User, "UserId").Cascade.None();
        }
    }
}