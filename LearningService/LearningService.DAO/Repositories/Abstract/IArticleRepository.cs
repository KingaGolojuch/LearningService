using LearningService.DAO.Entities;
using System.Collections.Generic;

namespace LearningService.DAO.Repositories.Abstract
{
    public interface IArticleRepository
    {
        IEnumerable<Article> Get();
        IEnumerable<Article> Get(string userId);
        Article GetById(int id);
        void Add(Article entity);
        void Update(Article entity);
    }
}
