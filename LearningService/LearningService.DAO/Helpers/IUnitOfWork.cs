using NHibernate;

namespace LearningService.DAO.Helpers
{
    public interface IUnitOfWork
    {
        ISession Session { get; set; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
