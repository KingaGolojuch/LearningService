using LearningService.DAO.Entities;
using LearningService.DAO.Helpers;
using LearningService.DAO.Repositories.Abstract;

namespace LearningService.DAO.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public ApplicationUser Get(string id)
        {
            return _unitOfWork.Session.Get<ApplicationUser>(id);
        }

        public void Add(User entity)
        {
            using (var transaction = _unitOfWork.Session.BeginTransaction())
            {
                _unitOfWork.Session.Save(entity);
                transaction.Commit();
            }
        }

        public void Update(User entity)
        {
            using (var transaction = _unitOfWork.Session.BeginTransaction())
            {
                _unitOfWork.Session.Update(entity);
                transaction.Commit();
            }
        }

        public User GetById(string id)
        {
            return _unitOfWork.Session.Get<User>(id);
        }
    }
}
