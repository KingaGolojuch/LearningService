using LearningService.DAO.Entities;
using LearningService.DAO.Helpers;
using LearningService.DAO.Repositories.Abstract;
using System.Collections.Generic;

namespace LearningService.DAO.Repositories.Concrete
{
    public class TestRepository : ITestRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IEnumerable<TestEntity> Get()
        {
            return _unitOfWork.Session.QueryOver<TestEntity>().List();
        }

        public TestEntity GetById(int id)
        {
            return _unitOfWork.Session.Get<TestEntity>(id);
        }
    }
}