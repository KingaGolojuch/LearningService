using LearningService.DAO.Entities;
using LearningService.DAO.Helpers;
using LearningService.DAO.Repositories.Abstract;
using System.Collections.Generic;

namespace LearningService.DAO.Repositories.Concrete
{
    public class LessonRepository : ILessonRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public LessonRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Add(Lesson entity)
        {
            using (var transaction = _unitOfWork.Session.BeginTransaction())
            {
                _unitOfWork.Session.Save(entity);
                transaction.Commit();
            }
        }

        public void AddOrUpdate(Lesson entity)
        {
            using (var transaction = _unitOfWork.Session.BeginTransaction())
            {
                _unitOfWork.Session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public void Merge(Lesson entity)
        {
            using (var transaction = _unitOfWork.Session.BeginTransaction())
            {
                _unitOfWork.Session.Merge(entity);
                transaction.Commit();
            }
        }

        public void Update(Lesson entity)
        {
            using (var transaction = _unitOfWork.Session.BeginTransaction())
            {
                _unitOfWork.Session.Update(entity);
                transaction.Commit();
            }
        }

        public Lesson GetById(int lessonId)
        {
            return _unitOfWork.Session.Get<Lesson>(lessonId);
        }

        public IEnumerable<Lesson> GetLessons(int courseId)
        {
            var course = _unitOfWork
                .Session
                .QueryOver<Course>()
                .Where(x => x.Id == courseId)
                .SingleOrDefault();
            
            return course?.Lessons;
        }
    }
}