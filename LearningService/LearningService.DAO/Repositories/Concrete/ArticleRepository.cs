using LearningService.DAO.Entities;
using LearningService.DAO.Helpers;
using LearningService.DAO.Repositories.Abstract;
using LearningService.Helpers;
using System.Collections.Generic;

namespace LearningService.DAO.Repositories.Concrete
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Article> Get()
        {
            return _unitOfWork
                .Session
                .QueryOver<Article>()
                .List<Article>();
        }

        public IEnumerable<Article> Get(string userId)
        {
            return _unitOfWork
                .Session
                .QueryOver<Article>()
                .JoinQueryOver<ApplicationUser>(x => x.User)
                .Where(x => x.Id == userId)
                .List<Article>();
        }

        public Article GetById(int id)
        {
            return _unitOfWork.Session.Get<Article>(id);
        }

        public void Add(Article entity)
        {
            using (var transaction = _unitOfWork.Session.BeginTransaction())
            {
                _unitOfWork.Session.Save(entity);
                transaction.Commit();
            }
        }

        public void Update(Article entity)
        {
            using (var transaction = _unitOfWork.Session.BeginTransaction())
            {
                _unitOfWork.Session.Update(entity);
                transaction.Commit();
            }
        }
    }
}
