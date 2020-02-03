using LearningService.DAO.Helpers;
using LearningService.DAO.Repositories.Abstract;
using LearningService.Helpers;

namespace LearningService.DAO.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public ApplicationUser Get(int id)
        {
            return _unitOfWork.Session.Get<ApplicationUser>(id);
        }
    }
}