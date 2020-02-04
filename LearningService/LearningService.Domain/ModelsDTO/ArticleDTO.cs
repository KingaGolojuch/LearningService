using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.Domain.ModelsDTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string ContentArticle { get; set; }
        public bool Active { get; set; }

        public string UserId { get; set; }
    }
}