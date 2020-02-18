using LearningService.DAO.Entities;

namespace LearningService.DAO.Repositories.Abstract
{
    public interface IUserRepository
    {
        void Add(User entity);
        void Update(User entity);
        ApplicationUser Get(string id);
        User GetById(string id);
    }
}
