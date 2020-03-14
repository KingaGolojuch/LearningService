using System;

namespace LearningService.Domain.ModelsDTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string ContentArticle { get; set; }
        public bool Active { get; set; }
        public string ContentShortened { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public string UserId { get; set; }
    }
}
