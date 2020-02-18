using LearningService.DAO.Entities;
using LearningService.DAO.Helpers;
using LearningService.DAO.Repositories.Abstract;
using System.Collections.Generic;

namespace LearningService.DAO.Repositories.Concrete
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Course> Get()
        {
            return _unitOfWork
                .Session
                .QueryOver<Course>()
                .List<Course>();
        }

        public IEnumerable<Course> Get(string userId)
        {
            return _unitOfWork
                .Session
                .QueryOver<Course>()
                .JoinQueryOver<ApplicationUser>(x => x.User)
                .Where(x => x.Id == userId)
                .List<Course>();
        }

        public Course GetById(int id)
        {
            return _unitOfWork.Session.Get<Course>(id);
        }

        public void Add(Course entity)
        {
            using (var transaction = _unitOfWork.Session.BeginTransaction())
            {
                _unitOfWork.Session.Save(entity);
                transaction.Commit();
            }
        }
    }
}