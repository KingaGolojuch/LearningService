using LearningService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.DAO.Entities
{
    public class Article
    {
        public virtual int Id { get; set; }
        public virtual string Headline { get; set; }
        public virtual string ContentArticle { get; set; }
        public virtual bool Active { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}