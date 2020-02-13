using LearningService.Domain.ModelsDTO;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Abstract
{
    public interface IArticleService
    {
        IEnumerable<ArticleDTO> Get(string userId);
        IEnumerable<ArticleDTO> GetActive(string userId);
        ArticleDTO Get(int id);
        void Add(ArticleDTO article);
        void Update(ArticleDTO article);
        void Delete(int articleId);
    }
}